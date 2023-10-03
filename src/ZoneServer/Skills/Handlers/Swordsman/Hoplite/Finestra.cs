using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Hoplite
{
	/// <summary>
	/// Handler for the Hoplite skill Finestra.
	/// </summary>
	[SkillHandler(SkillId.Hoplite_Finestra)]
	public class Finestra : ISelfSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Direction direction)
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
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			//caster.Components.Get<BuffComponent>()?.StartSkillBuff(BuffId.Finestra_Buff, caster, skill, TimeSpan.FromSeconds(15));
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Finestra_Buff, 0, 0, TimeSpan.FromSeconds(15), caster, caster));

			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);
			Send.ZC_NORMAL.Skill_45(caster);
		}
	}
}
