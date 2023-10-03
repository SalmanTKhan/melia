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

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Fire Wall.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_FireWall)]
	public class FireWall : IGroundSkillHandler
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
			var wallIds = new int[8];
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			for (var i = 0; i < 8; i++)
			{
				var wallId = ZoneServer.Instance.World.CreateHandle();
				Send.ZC_NORMAL.Skill_7F(caster, wallId, 1);
				wallIds[i] = wallId;
			}
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle);

			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			var radius = (int)skill.Data.SplashRange * 2;
			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				// Buff Id: 233, Duration: 10000
				var fireWallDebuff = new Buff(BuffId.FireWall_Debuff, 0, 0, TimeSpan.FromMilliseconds(10000), currentTarget, caster);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(fireWallDebuff);
			}
		}
	}
}
