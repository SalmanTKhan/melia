using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Shared.L10N;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Samdiveve.
	/// </summary>
	[SkillHandler(SkillId.Bokor_Samdiveve)]
	public class Samdiveve : IGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
			if (!caster.Position.InRange2D(farPos, maxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, Position.Zero);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			this.ExecuteSamdiveve(caster, skill);
		}

		/// <summary>
		/// Execute Samdiveve
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		private void ExecuteSamdiveve(ICombatEntity caster, Skill skill)
		{
			var position = caster.Position + new Position(-10f, 0, 10f);
			var direction = caster.Direction;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "Cleric_Samdiveve";
			var duration = 10f;
			var size = 120f;
			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1, 15f, effectHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.SamdiveveCaster", caster);
			trigger.Vars.Set("Melia.SamdiveveSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("BOKOR_SAMDIVEVE_ENTER", this.OnEnterSamdivevePad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			caster.Map.AddMonster(trigger);

			Task.Delay(TimeSpan.FromSeconds(duration))
				.ContinueWith(_ =>
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1, 15f, effectHandle, size, false));
		}

		/// <summary>
		/// Add specific buffs to a target.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void StartBuff(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.Decomposition_Debuff, TimeSpan.FromSeconds(10), caster);
		}

		/// <summary>
		/// Called when a target enters a Samdiveve pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterSamdivevePad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;
			if (initiator.IsBuffActive(BuffId.Decomposition_Debuff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.SamdiveveCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.SamdiveveSkill");

			if (caster.IsHostileFaction(initiator))
				this.StartBuff(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
