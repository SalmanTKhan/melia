using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Zone.Skills.Combat;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;
using Melia.Shared.Data.Database;
using Melia.Zone.Skills.SplashAreas;
using System.Collections.Generic;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Damballa.
	/// </summary>
	[SkillHandler(SkillId.Bokor_Damballa)]
	public class Damballa : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
			if (!caster.Position.InRange2D(farPos, maxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			if (!caster.TryGetBuff(BuffId.PowerOfDarkness_Buff, out var darkForceBuff) || darkForceBuff.OverbuffCounter < 10)
			{
				caster.ServerMessage(Localization.Get("Requires at least 10 stacks of Dark Force."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			darkForceBuff.OverbuffCounter -= 10;
			Send.ZC_BUFF_UPDATE(caster, darkForceBuff);

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			var forceId = ForceId.GetNew();
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, forceId, null);

			if (designatedTarget != null)
			{
				var skillHitResult = SCR_SkillHit(caster, designatedTarget, skill);
				designatedTarget.PlayEffect("F_rize004_dark_damballa", 5f, 0);
				designatedTarget.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, designatedTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.AdditionalHitCount = 6;
				hitInfo.Delay = 100;

				Send.ZC_HIT_INFO(caster, designatedTarget, hitInfo);
			}
		}
	}
}
