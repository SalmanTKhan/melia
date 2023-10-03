using System;
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

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Fire Ball.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_FireBall)]
	public class FireBall : IDynamicTargetSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 0.5f);
		}

		/// <summary>
		/// Handles skill behavior
		/// </summary>
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			Send.ZC_NORMAL.TextEffect(caster, "I_SYS_Text_Effect_None", "LV 1");

			var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
			if (!caster.Position.InRange2D(target.Position, maxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
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

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, target.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Position.GetDirection(target.Position), target?.Position ?? Position.Zero);

			var unkForceId = skillHandle;
			var damageDelay = TimeSpan.FromMilliseconds(0);
			var skillHitDelay = skill.Properties.HitDelay;

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, TimeSpan.Zero);
			hit.ForceId = unkForceId;

			Send.ZC_SKILL_RANGE_CIRCLE(caster, target.Position, skill.Data.SplashRange);
			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, hit);
		}
	}
}
