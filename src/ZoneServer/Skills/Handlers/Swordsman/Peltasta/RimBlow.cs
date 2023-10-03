using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Peltasta
{
	/// <summary>
	/// Handler for the Peltasta skill Rim Blow.
	/// </summary>
	[SkillHandler(SkillId.Peltasta_RimBlow)]
	public class RimBlow : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Zucken_Buff, 0, 0, TimeSpan.FromSeconds(3), caster, caster));
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				if (currentTarget.TakeDamage(skillHitResult.Damage, caster))
					Send.ZC_SKILL_CAST_CANCEL(caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_HIT_INFO(caster, hits);
			Send.ZC_NORMAL.Skill_45(caster);
		}
	}
}
