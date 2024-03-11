using System;
using Melia.Shared.Game.Const;
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
	/// Handle for the Curse of Debility, Receives constant damage.
	/// </summary>
	[BuffHandler(BuffId.CurseOfWeakness_Damage_Debuff)]
	public class CurseOfWeakness_Damage_Debuff : BuffHandler
	{
		private const float DarkBuffChance = 30f; // %

		public override void WhileActive(Buff buff)
		{
			if (buff.Caster is ICombatEntity caster
			&& caster.TryGetSkill(SkillId.Bokor_Hexing, out var skill))
			{
				var target = buff.Target;

				var skillHitResult = SCR_SkillHit(caster, target, skill);
				target.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);

				Send.ZC_HIT_INFO(caster, target, hitInfo);

				var rnd = RandomProvider.Get();

				if (rnd.NextDouble() < DarkBuffChance / 100f)
					caster.StartBuff(BuffId.PowerOfDarkness_Buff, TimeSpan.FromMinutes(1), caster);
			}
		}
	}
}
