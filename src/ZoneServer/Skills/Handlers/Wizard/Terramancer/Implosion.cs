using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Implosion.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_Implosion)]
	public class Implosion : IDynamicTargetSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_implosion_shot" : "voice_wiz_f_implosion_shot");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_implosion_shot" : "voice_wiz_f_implosion_shot");
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

			// Salman: Is this required? Clear's previous skill effect?
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			if (target == null)
			{
				Send.ZC_NORMAL.Skill_40(caster, skill, caster.Direction, 1, 500, 1, 1, 0, 1, 0, 0, 512, 0);
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var damageDelay = TimeSpan.Zero;
			var skillHitDelay = TimeSpan.Zero;

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.StartBuff(BuffId.DecreaseHeal_Debuff, skill.Level, 0, TimeSpan.FromSeconds(4), caster);
			target.TakeDamage(skillHitResult.Damage, caster);

			var skillHit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
			skillHit.ForceId = ForceId.GetNew();

			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill);

			var forceId = ForceId.GetNew();
			var hitInfo = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);
			hitInfo.ForceId = forceId;
			hitInfo.HitCount = 4;

			Send.ZC_HIT_INFO(caster, target, hitInfo);
		}
	}
}
