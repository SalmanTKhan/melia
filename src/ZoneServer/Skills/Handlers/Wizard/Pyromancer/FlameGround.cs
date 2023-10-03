using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Flame Ground.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_FlameGround)]
	public class FlameGround : IGroundSkillHandler
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

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, hits);
			Send.ZC_NORMAL.SkillPad(caster, skill, "Pyromancer_FlameGround", farPos, caster.Direction, 2.551542f, 0.9648228f, skillHandle, 100);

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var buff = new Buff(BuffId.FireWall_Debuff, 0, 0, TimeSpan.FromSeconds(8), currentTarget, caster);
				//buff.Skill = skill;
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				currentTarget.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(400));
			}
			Task.Delay(TimeSpan.FromSeconds(8)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, "Pyromancer_FlameGround", farPos, caster.Direction, 2.551542f, 0.9648228f, skillHandle, 100, false));
		}
	}
}
