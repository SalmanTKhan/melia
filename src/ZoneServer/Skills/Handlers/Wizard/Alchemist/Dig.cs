using System;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Shared.L10N;
using Melia.Zone.Skills.Combat;
using Melia.Shared.Data.Database;
using Melia.Zone.World.Items;

namespace Melia.Zone.Skills.Handlers.Alchemist
{
	/// <summary>
	/// Handler for the Alchemist skill Dig.
	/// </summary>
	[SkillHandler(SkillId.Alchemist_Dig)]
	public class Dig : IGroundSkillHandler
	{
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
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			// TODO: Figure out this mechanic of what item drops.
			var dropItem = new Item(ItemId.Misc_Soil);
			dropItem.Drop(caster.Map, originPos, farPos);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(449));
		}
	}
}
