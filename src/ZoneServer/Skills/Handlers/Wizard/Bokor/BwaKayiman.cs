using System;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.Bokor
{
	/// <summary>
	/// Handler for the Bokor skill Bwa Kayiman.
	/// </summary>
	[SkillHandler(SkillId.Bokor_BwaKayiman)]
	public class BwaKayiman : IGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			var maxRange = skill.Properties.GetFloat(PropertyName.MaxR);
			if (!caster.Position.InRange2D(farPos, maxRange))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			if (!caster.TryGetBuff(BuffId.PowerOfDarkness_Buff, out var darkForceBuff) || darkForceBuff.OverbuffCounter < 10)
			{
				caster.ServerMessage(Localization.Get("Requires at least 10 stacks of Dark Force."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			darkForceBuff.OverbuffCounter -= 10;
			Send.ZC_BUFF_UPDATE(caster, darkForceBuff);

			skill.IncreaseOverheat();

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, Position.Zero);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			caster.StartBuff(BuffId.BwaKayiman_Buff, TimeSpan.FromSeconds(10), caster);
			this.ExecuteBwaKayiman(caster, skill);
		}

		/// <summary>
		/// Execute Bwa Kayiman
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		private void ExecuteBwaKayiman(ICombatEntity caster, Skill skill)
		{
			var position = caster.Position + new Position(-10f, 0, 10f);
			var direction = caster.Direction;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "Bokor_BwaKayiman";
			var duration = 10f;
			var size = 120f;
			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1, 15f, effectHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.BwaKayimanCaster", caster);
			trigger.Vars.Set("Melia.BwaKayimanSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("BOKOR_BWA_KAYIMAN_ENTER", this.OnEnterBwaKayimanPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			caster.Map.AddMonster(trigger);

			Task.Delay(TimeSpan.FromSeconds(duration))
				.ContinueWith(_ =>
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1, 15f, effectHandle, size, false));
		}

		/// <summary>
		/// Removes specific debuffs from a target.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void RemoveDebuffs(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			// TODO: Something about do additional damage per buff removed
			target.StopBuff(BuffId.Pollution_Debuff);
			target.StopBuff(BuffId.CurseOfWeakness_Damage_Debuff);
		}

		/// <summary>
		/// Called when a target enters a Bwa Kayiman pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterBwaKayimanPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;
			if (initiator.IsBuffActive(BuffId.BwaKayiman_Buff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.BwaKayimanCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.BwaKayimanSkill");

			if (caster.IsHostileFaction(initiator))
			{
				this.RemoveDebuffs(caster, initiator, skill);
			}
			else if (caster is Character character
				&& initiator is Character target
				&& character.PartyId > 0
				&& character.PartyId == target.PartyId)
				target.StartBuff(BuffId.BwaKayiman_Buff, TimeSpan.FromSeconds(10));

			return Task.CompletedTask;
		}
	}
}
