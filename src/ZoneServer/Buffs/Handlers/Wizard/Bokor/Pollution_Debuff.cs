using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters.Components;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Pollution, Receives constant damage.
	/// </summary>
	[BuffHandler(BuffId.Pollution_Debuff)]
	public class Pollution_Debuff : BuffHandler
	{
		public override void WhileActive(Buff buff)
		{
			if (buff.Caster is ICombatEntity caster && caster.TryGetSkill(SkillId.Bokor_Effigy, out var skill))
			{
				var target = buff.Target;
				var skillHitResult = SCR_SkillHit(caster, target, skill);
				var hitInfo = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);

				target.TakeDamage(skillHitResult.Damage, caster);

				Send.ZC_HIT_INFO(caster, target, hitInfo);
			}
		}
	}
}