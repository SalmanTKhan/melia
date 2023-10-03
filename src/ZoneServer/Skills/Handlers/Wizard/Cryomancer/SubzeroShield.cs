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

namespace Melia.Zone.Skills.Handlers.Cryomancer
{
	/// <summary>
	/// Handler for the Cryomancer skill Subzero Shield.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_SubzeroShield)]
	public class SubzeroShield : IGroundSkillHandler
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

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, caster.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			// Add Buff Id: Subzero_Buff Duration: 1800000
			var buff = new Buff(BuffId.Subzero_Buff, 0, 0, TimeSpan.FromMilliseconds(180000), caster, caster);

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(400));
			Send.ZC_SKILL_RANGE_FAN(caster, originPos, caster.Direction, 0, 0.1396263f);
			Send.ZC_SKILL_MELEE_TARGET(caster, skill, caster);

			Send.ZC_NORMAL.Skill_45(caster);
			Send.ZC_NORMAL.SetSkill_7B(caster, skill.Id);
		}
	}
}
