using System;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Shared.L10N;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Mackangdal.
	/// </summary>
	[SkillHandler(SkillId.Bokor_Mackangdal)]
	public class Mackangdal : IGroundSkillHandler
	{
		/// <summary>
		/// Handle Skill Behavior
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
			if (!caster.Components.Get<BuffComponent>().TryGet(BuffId.PowerOfDarkness_Buff, out var darkForceBuff))
			{
				caster.ServerMessage(Localization.Get("Requires Dark Force."));
				return;
			}

			skill.IncreaseOverheat();

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var duration = Math.Min(darkForceBuff.OverbuffCounter * 500, 10000);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.StartBuff(BuffId.Mackangdal_Buff, skill.Level, 0, TimeSpan.FromMilliseconds(duration), caster);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
		}
	}
}
