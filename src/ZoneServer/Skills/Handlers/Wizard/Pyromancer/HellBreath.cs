using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Hell Breath.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_HellBreath)]
	public class HellBreath : IGroundSkillHandler, IDynamicCasted
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
			Send.ZC_NORMAL.SkillPad(caster, skill, "Pyromancer_HellBreath", farPos, caster.Direction, 0.7853983f, 0f, skillHandle, 15);

			var buff = new Buff(BuffId.HellBreath_Buff, 0, 0, TimeSpan.Zero, caster, caster);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				buff = new Buff(BuffId.FireWall_Debuff, 0, 0, TimeSpan.FromSeconds(8), currentTarget, caster);
				//buff.Skill = skill;
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(400));
			}
			//Task.Delay(TimeSpan.FromSeconds(8)).ContinueWith(_ => Send.ZC_NORMAL.Skill(caster, skill, 370292, farPos, caster.Direction, 2.551542f, 0.9648228f, skillHandle, 100));
		}

		/// <summary>
		/// Handle cast ending behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="castTime"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// ?
			Send.ZC_SKILL_DISABLE(caster);
			Send.ZC_NORMAL.SkillCancel(caster, skill.Id);
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, "skl_eff_pyromancer_hellbreath_abil");
				Send.ZC_NORMAL.SetSkill_7B(character, skill.Id);
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 0);
			}
		}

		/// <summary>
		/// Handle casting start behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="maxCastTime"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Method intentionally left empty.
		}
	}
}
