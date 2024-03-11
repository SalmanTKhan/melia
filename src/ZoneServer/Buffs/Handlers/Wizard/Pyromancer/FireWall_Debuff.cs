using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Fire, Reduced Fire resistance for debuffed enemies..
	/// </summary>
	[BuffHandler(BuffId.FireWall_Debuff)]
	public class FireWall_Debuff : BuffHandler
	{
		private const float FireResistance = -20f;

		public override void OnStart(Buff buff)
		{
			if (buff.Target is Character)
				buff.Target.Properties.Modify(PropertyName.ResFire_BM, FireResistance);
			else
				buff.Target.Properties.Modify(PropertyName.Fire_Def, FireResistance);
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Target is Character)
				buff.Target.Properties.Modify(PropertyName.ResFire_BM, -FireResistance);
			else
				buff.Target.Properties.Modify(PropertyName.Fire_Def, -FireResistance);
		}

		public override void WhileActive(Buff buff)
		{
			if (buff.Caster is ICombatEntity caster && caster.TryGetSkill(SkillId.Pyromancer_FireWall, out var skill))
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
