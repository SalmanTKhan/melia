using System;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Jaguar
{
	/// <summary>
	/// Handler for the Jaguar skill Wild Rush.
	/// </summary>
	[SkillHandler(SkillId.Jaguar_WildRush)]
	public class WildRush : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			var castRange = originPos.Get2DDistance(farPos);
			if (castRange > (skill.Data.MaxRange + 1f))
			{
				Log.Warning("Wild Rush: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				Send.ZC_SKILL_CAST_CANCEL(caster);
				return;
			}

			skill.IncreaseOverheat();

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			Send.ZC_NORMAL.LeapJump(caster, new Position(caster.Position.X, caster.Position.Y, caster.Position.Z + 100), 20, 0.1f, 0.1f, 1, 0.2f, 1);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(200));
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);


			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				// TODO: Didn't finish this, a copy of the control blade behavior was here.
			}
		}
	}
}
