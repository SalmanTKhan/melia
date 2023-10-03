using System;
using Melia.Zone.Network;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Zone.Skills.Combat;
using Melia.Shared.L10N;
using System.Collections.Generic;
using static Melia.Zone.Skills.SkillUseFunctions;
using Melia.Shared.Data.Database;

namespace Melia.Zone.Skills.Handlers.Doppelsoeldner
{
	/// <summary>
	/// Handler for the Doppelsoeldner skill Cyclone.
	/// </summary>
	[SkillHandler(SkillId.Doppelsoeldner_Cyclone)]
	public class Cyclone : IDynamicGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			// We'll ignore the data sent by the client and get the
			// positions ourselves, because players are dirty cheaters
			// who can't be trusted.
			originPos = caster.Position;
			farPos = originPos.GetRelative(caster.Direction, skill.Data.SplashHeight);

			var splashParam = skill.GetSplashParameters(caster, originPos, farPos, length: 30, width: 40, angle: 0);
			var splashArea = skill.GetSplashArea(SplashType.Circle, splashParam);
			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);
			var damageDelay = TimeSpan.FromMilliseconds(50);
			var skillHitDelay = skill.Properties.HitDelay;

			Debug.ShowShape(caster.Map, splashArea, edgePoints: false);

			var skillHits = new List<SkillHitInfo>();
			var hits = new List<HitInfo>();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var forceId = ForceId.GetNew();

				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				skillHit.ForceId = forceId;
				skillHits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, skillHits);

			var buff = new Buff(BuffId.Cyclone_EnableMovingShot_Buff, 0, 0, TimeSpan.Zero, caster, caster);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);

			/**
			foreach (var skillHit in skillHits)
			{
				Send.ZC_HIT_INFO(caster, skillHit.Target, skill, skillHit.HitInfo);
				if (skillHit.ApplyDamage())
					Send.ZC_SKILL_CAST_CANCEL(caster);
			}
			**/
		}

		/// <summary>
		/// Handle cast ending behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="castTime"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			Send.ZC_SKILL_DISABLE(caster);
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.Cyclone_EnableMovingShot_Buff);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 0);
		}

		/// <summary>
		/// Handle casting start behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>.
		/// <param name="maxCastTime"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			// Method intentionally left empty.
		}
	}
}
