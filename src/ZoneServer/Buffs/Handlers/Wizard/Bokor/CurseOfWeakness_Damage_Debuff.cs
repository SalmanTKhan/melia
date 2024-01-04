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
	/// Handle for the Curse of Debility, Receives constant damage.
	/// </summary>
	[BuffHandler(BuffId.CurseOfWeakness_Damage_Debuff)]
	public class CurseOfWeakness_Damage_Debuff : BuffHandler
	{
		private const float DarkBuffChance = 30f; // %

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			//Send.ZC_SHOW_EMOTICON(target, "I_emo_curse", buff.Duration);
		}

		public override void WhileActive(Buff buff)
		{
			if (buff.Caster is ICombatEntity caster)
			{
				var skill = caster.Components?.Get<SkillComponent>()?.Get(SkillId.Bokor_Hexing);
				var target = buff.Target;

				var skillHitResult = SCR_SkillHit(caster, target, skill);
				target.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);

				Send.ZC_HIT_INFO(caster, target, hitInfo);

				var rnd = RandomProvider.Get();

				if (rnd.NextDouble() < DarkBuffChance / 100f)
				{
					caster.StartBuff(BuffId.PowerOfDarkness_Buff, TimeSpan.FromMinutes(1), caster);
				}
			}
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			//Send.ZC_SHOW_EMOTICON(target, "I_emo_curse", TimeSpan.Zero);
		}
	}
}
