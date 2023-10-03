using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Chronomancer
{
	/// <summary>
	/// Handler for the Chronomancer skill Slow.
	/// </summary>
	[SkillHandler(SkillId.Chronomancer_Slow)]
	public class Slow : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 2);
		}

		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
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
			skill.IncreaseOverheat();

			// Is this correct, why is "Chronomancer_Slow" not being sent here?
			Send.ZC_NORMAL.SkillPad(caster, skill, "Chronomancer_Slow", farPos, caster.Direction, 0.06292176f, 85.76556f, skillHandle, 60);

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);

			Send.ZC_SKILL_RANGE_CIRCLE(caster, originPos, 50);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				Send.ZC_NORMAL.PlayTextEffect(currentTarget, caster, AnimationName.ShowBuffText, 301);
				var slowDebuff = new Buff(BuffId.Slow_Debuff, 0, 0, TimeSpan.FromSeconds(10), currentTarget, caster);
				//slowDebuff.Skill = skill;
				currentTarget.Components.Get<BuffComponent>().AddOrUpdate(slowDebuff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(100));
			}
		}
	}
}
