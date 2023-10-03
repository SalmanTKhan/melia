using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Priest
{
	/// <summary>
	/// Handler for the Priest skill Resurrection.
	/// </summary>
	[SkillHandler(SkillId.Priest_Resurrection)]
	public class Resurrection : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			Send.ZC_SKILL_DISABLE(caster);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));

			// Wasn't able to test on a player
			//Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			//Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);
		}
	}
}
