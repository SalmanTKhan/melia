using System;
using System.Collections.Generic;
using Melia.Shared.Data.Database;
using System.Linq;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Ranger
{
	/// <summary>
	/// Handler for the Ranger skill Barrage.
	/// </summary>
	[SkillHandler(SkillId.Ranger_Barrage)]
	public class Barrage : ITargetSkillHandler
	{
		/// <summary>
		/// Handles the skill, attacking the targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="target"></param>
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
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			if (!caster.InSkillUseRange(skill, target))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			if (caster.TryGetSkill(SkillId.Ranger_Strafe, out var _))
				caster.StartBuff(BuffId.Ranger_StrapingShot, TimeSpan.FromSeconds(3), caster);

			var damageDelay = TimeSpan.FromMilliseconds(32);
			var skillHitDelay = TimeSpan.FromMilliseconds(0);

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var skillHit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
			skillHit.ForceId = ForceId.GetNew();
			skillHit.UnkFloat = 8;

			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, skillHit);

			var skillHitResultPost = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResultPost.Damage, caster);

			var hit = new HitInfo(caster, target, skill, skillHitResultPost.Damage, skillHitResultPost.Result);
			hit.UnkFloat2 = 0.5f;
			Send.ZC_HIT_INFO(caster, target, hit);

			// Splash shot
			if (this.TryGetBounceTarget(caster, target, skill, out var bounceTarget))
			{
				var forceId = ForceId.GetNew();
				var splashEffect1 = "I_arrow009_red#Dummy_arrow"; //[i381465] 4912
				var scale1 = 0.7f;
				var splashEffect2 = "arrow_cast"; //[i381465] 13186
				var splashEffect3 = "F_archer_bodkinpoint_hit_explosion"; //[i381465] 6267
				var scale2 = 0.7f;
				var splashEffect4 = "arrow_blow"; //[i381465] 13187
				var splashEffect5 = "SLOW"; //[i381465] 13184
				var speed = 700f;
				Send.ZC_NORMAL.SkillEffectSplash(caster, caster, bounceTarget, forceId, splashEffect1, scale1, splashEffect2, splashEffect3, scale2, splashEffect4, splashEffect5, speed, 1, 5, 10, 0);

				var skillEffect = "F_archer_shot_light_orange"; //[i381465] 4917
				var skillScale = 0.3f;
				var str1 = "Dummy_arrow_effect";
				var str2 = "None";
				Send.ZC_NORMAL.SkillEffect_14(caster, skillEffect, skillScale, str1, str2);

				skillHitResult = SCR_SkillHit(caster, bounceTarget, skill);
				bounceTarget.TakeDamage(skillHitResult.Damage, caster);

				hit = new HitInfo(caster, bounceTarget, skill, skillHitResult);
				hit.UnkFloat1 = -1f;
				Send.ZC_HIT_INFO(caster, bounceTarget, hit);
			}
		}

		/// <summary>
		/// Returns the closest target to the main target to bounce the
		/// attack off to.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="mainTarget"></param>
		/// <param name="skill"></param>
		/// <param name="bounceTarget"></param>
		/// <returns></returns>
		private bool TryGetBounceTarget(ICombatEntity caster, ICombatEntity mainTarget, Skill skill, out ICombatEntity bounceTarget)
		{
			var splashPos = caster.Position;
			var splashParam = skill.GetSplashParameters(caster, splashPos, mainTarget.Position, length: 130, width: 60, angle: 0);
			var splashArea = skill.GetSplashArea(SplashType.Square, splashParam);
			Debug.ShowShape(caster.Map, splashArea, TimeSpan.FromSeconds(5));

			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);
			if (!targets.Any())
			{
				bounceTarget = null;
				return false;
			}

			bounceTarget = targets.Where(a => a != mainTarget).OrderBy(a => a.Position.Get2DDistance(mainTarget.Position)).FirstOrDefault();
			return bounceTarget != null;
		}
	}
}
