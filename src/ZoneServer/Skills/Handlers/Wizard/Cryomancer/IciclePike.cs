using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Icicle Pike.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IciclePike)]
	public class IciclePike : IDynamicGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);

			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, hits);

			var random = RandomProvider.Get();
			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				// 50% Chance of Cryomancer's Freeze occurring
				if (random.NextDouble() >= .5)
				{
					var buff = new Buff(BuffId.Cryomancer_Freeze, 0, 0, TimeSpan.FromSeconds(5), currentTarget, caster);
					//buff.Skill = skill;
					Send.ZC_NORMAL.PlayTextEffect(currentTarget, caster, AnimationName.ShowBuffText, 238);
					Send.ZC_NORMAL.StatusEffect(currentTarget, 5000, "Freeze", "Cryomancer_Freeze");
					Send.ZC_SYNC_START(caster, skillHandle, 1);
					currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
					Send.ZC_SYNC_END(caster, skillHandle, 0);
					Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
				}
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Method intentionally left empty.
		}

		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Method intentionally left empty.
		}
	}
}
