using System;
using Melia.Zone.Network;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Characters;
using Melia.Shared.L10N;

namespace Melia.Zone.Skills.Handlers.Jaguar
{
	/// <summary>
	/// Handler for the Jaguar skill Jaguar Stance.
	/// </summary>
	[SkillHandler(SkillId.Jaguar_JaguarStance)]
	public class JaguarStance : ISelfSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position farPos, Direction direction)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);

			if (caster is Character character)
				character.Components.Get<SkillComponent>()?.Add(new Skill(character, SkillId.Jaguar_Attack, 1));

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.Start(BuffId.JaguarStance_Buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
		}
	}
}
