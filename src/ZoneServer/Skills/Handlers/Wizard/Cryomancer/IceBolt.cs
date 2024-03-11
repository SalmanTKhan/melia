using System;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Ice Bolt.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IceBolt)]
	public class IceBolt : IDynamicTargetSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
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
				Send.ZC_NORMAL.Skill_40(caster, skill, caster.Direction, 1, 500, 1, 0, 0, 1, 0, 0, 512, 0);
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, target.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Position.GetDirection(target.Position), target?.Position ?? Position.Zero);

			var unkForceId = skillHandle;
			var damageDelay = TimeSpan.FromMilliseconds(0);
			var splashTargets = caster.Map.GetAttackableEntitiesInRangeAroundEntity(caster, target, skill.Properties.GetFloat(PropertyName.SplRange), 5);
			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var skillHitInfo = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, TimeSpan.Zero);
			skillHitInfo.ForceId = unkForceId;

			// TODO: Move this into a status effect function or class?
			Send.ZC_NORMAL.StatusEffect(target, 5000, "Freeze", "Cryomancer_Freeze");
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, skillHitInfo);

			foreach (var splashTarget in splashTargets)
			{
				var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				Send.ZC_NORMAL.SkillEffectSplash(caster, target, splashTarget, effectHandle,
					"I_force110_ice", 0.5f, null, null, 1, null, "SLOW", 300,
					1, 1, 1, 0);
				Send.ZC_SYNC_END(caster, skillHandle, 0.1f);

				skillHitResult = SCR_SkillHit(caster, splashTarget, skill);
				splashTarget.TakeDamage(skillHitResult.Damage, caster);
				var hitInfo = new HitInfo(caster, splashTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.ForceId = effectHandle;
				Send.ZC_HIT_INFO(caster, splashTarget, hitInfo);
			}

			Send.ZC_NORMAL.Skill_45(caster);
			Send.ZC_NORMAL.SkillCancel(caster, skill.Id);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);
		}

		/// <summary>
		/// Handles skill cast starting behavior
		/// </summary>
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_icebolt_cast" : "voice_wiz_icebolt_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		/// <summary>
		/// Handles skill cast ending behavior
		/// </summary>
		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_icebolt_cast" : "voice_wiz_icebolt_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}
	}
}
