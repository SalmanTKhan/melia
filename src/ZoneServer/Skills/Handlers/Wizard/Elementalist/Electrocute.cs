using System.Collections.Generic;
using System.Linq;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Elementalist
{
	/// <summary>
	/// Handler for the Elementalist skill Electrocute.
	/// </summary>
	[SkillHandler(SkillId.Elementalist_Electrocute)]
	public class Electrocute : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(caster, character.Gender == Gender.Male ? "voice_wiz_m_electrocute_cast" : "voice_wiz_electrocute_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_electrocute_cast" : "voice_wiz_electrocute_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			if (designatedTarget != null)
			{
				var skillHitResult = SCR_SkillHit(caster, designatedTarget, skill);
				designatedTarget.TakeDamage(skillHitResult.Damage, caster);

				var hit = new HitInfo(caster, designatedTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hit.ForceId = ForceId.GetNew();
				Send.ZC_HIT_INFO(hit.Attacker, hit.Target, hit);

				var targets = caster.Map.GetAttackableEntitiesInRangeAroundEntity(caster, designatedTarget, skill.Properties.GetFloat(PropertyName.SplRange), 3);
				targets.Insert(0, designatedTarget);

				var syncKeyTargets = targets.Select(target => (target.Handle, ZoneServer.Instance.World.CreateSkillHandle())).ToArray();
				Send.ZC_NORMAL.Skill_125(caster, "I_laser005_blue#Dummy_effect_electrocute", 4, 0.2f, syncKeyTargets);

				foreach (var currentTarget in targets.LimitBySDR(caster, skill))
				{
					skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
					currentTarget.TakeDamage(skillHitResult.Damage, caster);

					hit = new HitInfo(caster, currentTarget, skill, skillHitResult.Damage, skillHitResult.Result);
					hit.ForceId = ForceId.GetNew();
					Send.ZC_HIT_INFO(hit.Attacker, hit.Target, hit);
					//if (skillHitResult.Result == HitResultType.Crit)
					//Send.ZC_NORMAL.PlayTextEffect(hit.Target, caster, AnimationName.ShowCriticalDamage, 0);
				}
			}
		}
	}
}
