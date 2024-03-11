using System;
using System.Linq;
using Melia.Shared.Data.Database;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Fletcher
{
	/// <summary>
	/// Handler for the Fletcher skill Fletcher Arrow Shot.
	/// </summary>
	[SkillHandler(SkillId.Fletcher_FletcherArrowShot)]
	public class FletcherArrowShot : ITargetSkillHandler
	{
		/// <summary>
		/// Handles the skill, shoot missile at enemy that spreads to another target.
		/// </summary>
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			var oldestBuff = caster.Components.Get<BuffComponent>()?.GetList()?
				.Where(b => (b.Id == BuffId.Fletcher_BarbedArrow_Buff
				|| b.Id == BuffId.Fletcher_BodkinPoint_Buff
				|| b.Id == BuffId.Fletcher_CrossFire_Buff
				|| b.Id == BuffId.Fletcher_Singijeon_Buff))
				.OrderBy(b => b.StartTime).FirstOrDefault();

			if (oldestBuff == null)
			{
				caster.ServerMessage(Localization.Get("No active buff found."));
				return;
			}

			if (!caster.InSkillUseRange(skill, target))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

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

			Skill buffSkill;
			switch (oldestBuff.Id)
			{
				case BuffId.Fletcher_BarbedArrow_Buff:
					caster.TryGetSkill(SkillId.Fletcher_BarbedArrow, out buffSkill);
					break;
				case BuffId.Fletcher_BodkinPoint_Buff:
					caster.TryGetSkill(SkillId.Fletcher_BodkinPoint, out buffSkill);
					break;
				case BuffId.Fletcher_CrossFire_Buff:
					caster.TryGetSkill(SkillId.Fletcher_CrossFire, out buffSkill);
					break;
				case BuffId.Fletcher_Singijeon_Buff:
					caster.TryGetSkill(SkillId.Fletcher_Singijeon, out buffSkill);
					break;
				default:
					Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
					return;
			}

			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			caster.StopBuff(oldestBuff.Id);
			buffSkill.IncreaseOverheat();

			// Probably should get the respective handler (though)
			if (buffSkill.Id == SkillId.Fletcher_BarbedArrow)
				this.HandleBarbedArrow(skill, buffSkill, caster, target);
			else if (buffSkill.Id == SkillId.Fletcher_BodkinPoint)
				this.HandleBodkinPoint(skill, buffSkill, caster, target);
			else if (buffSkill.Id == SkillId.Fletcher_CrossFire)
				this.HandleCrossFire(skill, buffSkill, caster, target);
			else if (buffSkill.Id == SkillId.Fletcher_Singijeon)
				this.HandleDivineMachineArrow(skill, buffSkill, caster, target);
		}

		private void HandleBarbedArrow(Skill fletcherSkill, Skill buffSkill, ICombatEntity caster, ICombatEntity target)
		{
			Send.ZC_SKILL_FORCE_TARGET(caster, target, fletcherSkill, ForceId.GetNew(), null);

			var skillHitResult = SCR_SkillHit(caster, target, buffSkill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, buffSkill, skillHitResult);
			hit.HitCount = 5;
			hit.UnkFloat1 = -1;
			hit.ForceId = ForceId.GetNew();
			Send.ZC_HIT_INFO(caster, target, hit);

			// Bounce shot
			if (this.TryGetBounceTarget(caster, target, buffSkill, out var bounceTarget))
			{
				skillHitResult = SCR_SkillHit(caster, bounceTarget, buffSkill);
				bounceTarget.TakeDamage(skillHitResult.Damage, caster);

				hit = new HitInfo(caster, bounceTarget, buffSkill, skillHitResult);
				Send.ZC_HIT_INFO(caster, bounceTarget, hit);
			}
		}

		private void HandleBodkinPoint(Skill fletcherSkill, Skill buffSkill, ICombatEntity caster, ICombatEntity target)
		{
			var forceId = ForceId.GetNew();
			var splashEffect1 = "I_arrow009_red#Dummy_arrow";
			var scale1 = 0.7f;
			var splashEffect2 = "arrow_cast";
			var scale2 = 1f;
			var splashEffect4 = "arrow_blow";
			var splashEffect5 = "SLOW";
			var speed = 800f;
			Send.ZC_NORMAL.SkillEffectSplash(caster, caster, target, forceId, splashEffect1, scale1, splashEffect2, null, scale2, splashEffect4, splashEffect5, speed, 1, 5, 10, 0);

			var skillEffect = "F_archer_shot_light_red";
			var skillScale = 0.6f;
			var str1 = "Dummy_arrow_effect";
			var str2 = "None";
			Send.ZC_NORMAL.SkillEffect_14(caster, skillEffect, skillScale, str1, str2);
			Send.ZC_SKILL_FORCE_TARGET(caster, target, fletcherSkill, forceId, null);

			var skillHitResult = SCR_SkillHit(caster, target, buffSkill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, buffSkill, skillHitResult);
			hit.ForceId = ForceId.GetNew();
			Send.ZC_HIT_INFO(caster, target, hit);

			// Bounce shot
			if (this.TryGetBounceTarget(caster, target, buffSkill, out var bounceTarget))
			{
				skillHitResult = SCR_SkillHit(caster, bounceTarget, buffSkill);
				bounceTarget.TakeDamage(skillHitResult.Damage, caster);

				hit = new HitInfo(caster, bounceTarget, buffSkill, skillHitResult);
				Send.ZC_HIT_INFO(caster, bounceTarget, hit);
			}
		}

		private void HandleCrossFire(Skill fletcherSkill, Skill buffSkill, ICombatEntity caster, ICombatEntity target)
		{
			var forceId = ForceId.GetNew();
			var splashEffect1 = "I_arrow009_yellow#Dummy_arrow";
			var scale1 = 0.7f;
			var splashEffect3 = "F_archer_crossarrow_shot_ground";
			var scale2 = 1f;
			var splashEffect5 = "FAST";
			var speed = 500f;
			Send.ZC_NORMAL.SkillEffectSplash(caster, caster, target, forceId, splashEffect1, scale1, null, splashEffect3, scale2, null, splashEffect5, speed, 0, 0, 0, 0);

			var groundEffect = "E_archer_crossarrow_shot_ground";
			var groundEffectScale = 1.3f;

			Send.ZC_GROUND_EFFECT(caster, groundEffect, target.Position, groundEffectScale, 0, 0.2f);

			Send.ZC_SKILL_FORCE_TARGET(caster, target, fletcherSkill, forceId, null);

			var skillHitResult = SCR_SkillHit(caster, target, buffSkill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, buffSkill, skillHitResult);
			Send.ZC_HIT_INFO(caster, target, hit);

			// Bounce shot
			if (this.TryGetBounceTarget(caster, target, buffSkill, out var bounceTarget))
			{
				skillHitResult = SCR_SkillHit(caster, bounceTarget, buffSkill);
				bounceTarget.TakeDamage(skillHitResult.Damage, caster);

				hit = new HitInfo(caster, bounceTarget, buffSkill, skillHitResult);
				Send.ZC_HIT_INFO(caster, bounceTarget, hit);
			}
		}

		private void HandleDivineMachineArrow(Skill fletcherSkill, Skill buffSkill, ICombatEntity caster, ICombatEntity target)
		{
			var forceId = ForceId.GetNew();
			var splashEffect1 = "E_archer_Flareshot_arrow_violet#Dummy_arrow";
			var scale1 = 0.3f;
			var splashEffect3 = "";
			var scale2 = 0.5f;
			var splashEffect5 = "FAST";
			var speed = 700f;
			Send.ZC_NORMAL.SkillEffectSplash(caster, caster, target, forceId, splashEffect1, scale1, null, splashEffect3, scale2, null, splashEffect5, speed, 0, 0, 0, 0);

			var groundEffect = "I_explosion002_orange";
			var groundEffectScale = 1.5f;
			Send.ZC_GROUND_EFFECT(caster, groundEffect, target.Position, groundEffectScale, 0, 0.2f);

			groundEffect = "F_archer_caltrop_hit_explosion";
			groundEffectScale = 1f;
			Send.ZC_GROUND_EFFECT(caster, groundEffect, target.Position, groundEffectScale, 0, 0.1f);

			Send.ZC_SKILL_FORCE_TARGET(caster, target, fletcherSkill, forceId, null);

			var skillHitResult = SCR_SkillHit(caster, target, buffSkill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, buffSkill, skillHitResult);
			Send.ZC_HIT_INFO(caster, target, hit);

			// Bounce shot
			if (this.TryGetBounceTarget(caster, target, buffSkill, out var bounceTarget))
			{
				skillHitResult = SCR_SkillHit(caster, bounceTarget, buffSkill);
				bounceTarget.TakeDamage(skillHitResult.Damage, caster);

				hit = new HitInfo(caster, bounceTarget, buffSkill, skillHitResult);
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
			Debug.ShowShape(caster.Map, splashArea, TimeSpan.FromMilliseconds(250));

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
