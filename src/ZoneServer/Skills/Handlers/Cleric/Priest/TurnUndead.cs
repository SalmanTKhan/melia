using System.Collections.Generic;
using System;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Shared.L10N;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Priest
{
	/// <summary>
	/// Handler for the Priest skill Turn Undead.
	/// </summary>
	[SkillHandler(SkillId.Priest_TurnUndead)]
	public class TurnUndead : IGroundSkillHandler
	{
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

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);
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
		}
	}
}
