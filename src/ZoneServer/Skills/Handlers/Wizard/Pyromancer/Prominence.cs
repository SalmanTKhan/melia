using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Prominence.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_Prominence)]
	public class Prominence : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 0.09375f);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 1);
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
			if (!caster.Position.InRange2D(farPos, maxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(target);
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_NORMAL.SkillPad(caster, skill, "prominence", farPos, caster.Direction, -1, 25, skillHandle, 0);
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var prominenceIds = new[] { ZoneServer.Instance.World.CreateSkillHandle(), ZoneServer.Instance.World.CreateSkillHandle(), ZoneServer.Instance.World.CreateSkillHandle(), ZoneServer.Instance.World.CreateSkillHandle() };

			for (var i = 0; i < 4; i++)
			{
				var startPosition = farPos.GetRandomInRange2D(5, 10);
				var endPosition = startPosition.GetRandomInRange2D(10, 15);
				Send.ZC_NORMAL.Skill_124(caster, prominenceIds[i], "I_wizard_Prominence_force_fire3", 1.2f, "F_wizard_prominence_fire", 1, 90, 5, 25, 0.35f, 5, 0.35f, startPosition, 2);
				Send.ZC_NORMAL.Skill_124(caster, prominenceIds[i], startPosition, endPosition);
			}

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 2);
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

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var buff = new Buff(BuffId.Fire, 0, 0, TimeSpan.FromSeconds(3), currentTarget, caster);
				//buff.Skill = skill;
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));
			}
			for (var i = 0; i < 5; i++)
			{
				Task.Delay(1000 * (i + 1)).ContinueWith(_ =>
				{
					var startPosition = farPos.GetRandomInRange2D(5, 10);
					var endPosition = startPosition.GetRandomInRange2D(10, 15);
					for (var j = 0; j < 5; j++)
						Send.ZC_NORMAL.Skill_124(caster, prominenceIds[j], startPosition, endPosition);
				});
				if (i == 4)
				{
					Task.Delay(1000 * (i + 1)).ContinueWith(_ =>
					{
						for (var j = 0; j < 5; j++)
							Send.ZC_NORMAL.Skill_124(caster, prominenceIds[j]);
					});
				}
			}
		}
	}
}
