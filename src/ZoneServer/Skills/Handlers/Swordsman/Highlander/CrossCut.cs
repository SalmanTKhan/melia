using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Highlander
{
	/// <summary>
	/// Handler for the Highlander skill Cross Cut.
	/// </summary>
	[SkillHandler(SkillId.Highlander_CrossCut)]
	public class CrossCut : IGroundSkillHandler
	{
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

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				Send.ZC_NORMAL.PlayTextEffect(currentTarget, caster, AnimationName.ShowBuffText, 254);
				var crossCutDebuff = new Buff(BuffId.CrossCut_Debuff, 0, 0, TimeSpan.FromSeconds(6), currentTarget, caster);
				//crossCutDebuff.Skill = skill;
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(crossCutDebuff);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
		}
	}
}
