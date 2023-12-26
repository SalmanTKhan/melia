using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.Chronomancer
{
	/// <summary>
	/// Handler for the Chronomancer skill Stop.
	/// </summary>
	[SkillHandler(SkillId.Chronomancer_Stop)]
	public class Stop : IGroundSkillHandler
	{
		/// <summary>
		/// Handles skill, damaging targets.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			//skill.IncreaseOverheat();
			caster.SetAttackState(true);

			this.ExecuteStop(caster, target, skill);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
		}

		private void ExecuteStop(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			var position = caster.Position;
			var direction = caster.Direction;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			Send.ZC_NORMAL.SkillPad(caster, skill, skill.Data.ClassName, caster.Position, caster.Direction, 2.356195f, 0, effectHandle, 70);

			var area = new CircleF(position, 70);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, caster.Position), caster.Direction);
			trigger.Vars.Set("Melia.StopCaster", caster);
			trigger.Vars.Set("Melia.StopSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("CHRONOMANCER_STOP_ENTER", this.OnEnterStopPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(10);
			caster.Map.AddMonster(trigger);

			Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, skill.Data.ClassName, position, direction, 2.356195f, 0, effectHandle, 70, false));
		}

		/// <summary>
		/// Stops a target directly with a buff.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void BuffStop(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.Stop_Debuff, 0, 0, TimeSpan.FromSeconds(10), caster);
		}

		/// <summary>
		/// Called when a target enters a stop pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterStopPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;

			if (initiator.IsBuffActive(BuffId.Stop_Debuff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.StopCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.StopSkill");

			if (caster.IsHostileFaction(initiator))
				this.BuffStop(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
