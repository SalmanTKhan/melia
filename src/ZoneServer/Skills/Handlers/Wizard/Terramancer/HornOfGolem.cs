using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Horn Of Golem.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_HornOfGolem)]
	public class HornOfGolem : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_hornofgolem_shot" : "voice_wiz_f_hornofgolem_shot");
				Send.ZC_PLAY_SOUND(character, "skl_eff_hornofgolem_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_hornofgolem_shot" : "voice_wiz_f_hornofgolem_shot");
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

			var groundEffectHandle = ZoneServer.Instance.World.CreateEffectHandle();

			Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, originPos);
			Send.ZC_NORMAL.SkillPad(caster, skill, "TerraMancer_HornOfGolem", caster.Position, caster.Direction, 0, 0, groundEffectHandle, 60);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
			Send.ZC_NORMAL.Skill_EffectMovement(caster, groundEffectHandle, farPos.GetRelative(caster.Direction, 150), 250, 1, 50);
			Task.Delay(550).ContinueWith(_ =>
			{
				Send.ZC_NORMAL.SkillPad(caster, skill, "TerraMancer_HornOfGolem", caster.Position, caster.Direction, 0, 0, groundEffectHandle, 100, false);
			});
		}
	}
}
