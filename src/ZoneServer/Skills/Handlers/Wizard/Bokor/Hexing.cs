using System;
using System.Collections.Generic;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Yggdrasil.Geometry.Shapes;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Hexing.
	/// </summary>
	[SkillHandler(SkillId.Bokor_Hexing)]
	public class Hexing : ITargetSkillHandler
	{
		/// <summary>
		/// Handles the skill, attacking the targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.SetAttackState(true);

			if (designatedTarget == null)
			{
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			if (!caster.InSkillUseRange(skill, designatedTarget))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var damageDelay = TimeSpan.FromMilliseconds(350);
			var skillHitDelay = TimeSpan.Zero;
			var skillHitResult = SCR_SkillHit(caster, designatedTarget, skill);
			var skillHit = new SkillHitInfo(caster, designatedTarget, skill, skillHitResult, damageDelay, skillHitDelay);
			skillHit.ForceId = ForceId.GetNew();

			designatedTarget.TakeDamage(skillHitResult.Damage, caster);

			// Official server sends force id in the target packet but sends a seperate
			// skill hit info packet with the actual hit data.
			Send.ZC_SKILL_FORCE_TARGET(caster, designatedTarget, skill, skillHit.ForceId, null);
			Send.ZC_SKILL_HIT_INFO(caster, skillHit);

			caster.StartBuff(BuffId.CurseOfWeakness_Pre_Buff, TimeSpan.FromSeconds(30));
			designatedTarget.StartBuff(BuffId.CurseOfWeakness_Damage_Debuff, TimeSpan.FromSeconds(30), caster);
		}
	}
}
