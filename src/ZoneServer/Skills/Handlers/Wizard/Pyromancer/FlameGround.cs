using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
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

			this.ExecuteFlameGround(caster, caster.Position, skill);
		}

		/// <summary>
		/// Execute Fire Pillar
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void ExecuteFlameGround(ICombatEntity caster, Position targetPos, Skill skill)
		{
			var position = targetPos + new Position(-1, 0, 1); // Not too sure if offset is needed.
			var direction = caster.Direction;
			var packetStringId = "Pyromancer_FlameGround";
			var duration = 8f;
			var size = 100f;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 2.551538f, 0.9648184f, effectHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.FlameGroundCaster", caster);
			trigger.Vars.Set("Melia.FlameGroundSkill", skill);
			trigger.Vars.Set("Melia.FlameGroundTargetLimit", 10);
			trigger.SetTriggerArea(area);
			trigger.SetWhileInsideTrigger("PYROMANCER_FLAME_GROUND_ENTER", this.OnEnterFlameGroundPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			caster.Map.AddMonster(trigger);

			trigger.OnDisappear += () =>
			{
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, -0.2594702f, 62.63292f, effectHandle, 50, false);
			};
		}

		/// <summary>
		/// Burns a target directly with a buff.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void BuffFlameGround(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.FireWall_Debuff, 0, 0, TimeSpan.Zero, caster);
		}

		/// <summary>
		/// Called when a target enters a flame ground pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterFlameGroundPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.FlameGroundCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.FlameGroundSkill");

			if (caster.IsHostileFaction(initiator))
				this.BuffFlameGround(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
