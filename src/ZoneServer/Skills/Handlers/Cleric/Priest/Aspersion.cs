using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Priest
{
	/// <summary>
	/// Handler for the Priest skill Aspersion.
	/// </summary>
	[SkillHandler(SkillId.Priest_Aspersion)]
	public class Aspersion : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior.
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
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			var buff = new Buff(BuffId.Aspersion_Buff, 0, 0, TimeSpan.FromMinutes(30), caster, caster);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle);

			if (caster is Character character)
			{
				var party = character.Connection.Party;
				if (party != null)
				{
					// Get party members in skill range and apply buff
				}
			}
		}
	}
}
