using System;
using System.Collections.Generic;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Shared.L10N;
using Melia.Zone.Skills.Combat;
using static Melia.Zone.Skills.SkillUseFunctions;
using Melia.Zone.Skills.SplashAreas;

namespace Melia.Zone.Skills.Handlers.Alchemist
{
	/// <summary>
	/// Handler for the Alchemist skill Alchemistic Missile.
	/// </summary>
	[SkillHandler(SkillId.Alchemist_AlchemisticMissile)]
	public class AlchemisticMissile : IDynamicTargetSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_alchemisticmissile_shot" : "voice_wiz_f_alchemisticmissile_shot");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_NORMAL.TextEffect(caster, "I_SYS_Text_Effect_None", "LV 1");
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_alchemisticmissile_shot" : "voice_wiz_f_alchemisticmissile_shot");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}

		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(target);
			caster.SetAttackState(true);

			if (target == null)
			{
				Send.ZC_NORMAL.Skill_40(caster, skill, caster.Direction, 2, 500, 1, 0, 0, 1, 0, 0, 512, 0);
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var damageDelay = TimeSpan.Zero;
			var skillHitDelay = TimeSpan.Zero;

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var skillHit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
			skillHit.ForceId = ForceId.GetNew();

			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, skillHit);

			Send.ZC_NORMAL.Skill_45(caster);
			Send.ZC_NORMAL.SkillCancel(caster, skill.Id);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);
		}
	}
}
