using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.Buffs;
using Melia.Shared.L10N;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.Scripting.Dialogues;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.Hunter
{
	/// <summary>
	/// Handler for the Hunter skill Bolas.
	/// </summary>
	[SkillHandler(SkillId.Hunter_Bolas)]
	public class Bolas : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				//Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!skill.Vars.TryGet<Position>("Melia.ToolGroundPos", out var targetPos))
			{
				caster.ServerMessage(Localization.Get("No target location specified."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			caster.SetAttackState(true);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, targetPos);

			var forceId = ForceId.GetNew();
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, forceId, null);

			this.ExecuteBolas(caster, skill, targetPos);
		}

		/// <summary>
		/// Execute Bolas
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="position"></param>
		private void ExecuteBolas(ICombatEntity caster, Skill skill, Position position)
		{
			var direction = caster.Direction;
			var padHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "Shootpad_Bolas";
			var duration = 5f;
			var size = 50f;

			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 0f, 25f, padHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.BolasCaster", caster);
			trigger.Vars.Set("Melia.BolasSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("HUNTER_BOLAS_ENTER", this.OnEnterBolas);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			trigger.OwnerHandle = caster.Handle;
			trigger.AssociatedHandle = caster.Handle;
			caster.Map.AddMonster(trigger);

			trigger.OnDisappear += () =>
			{
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 0f, 25f, padHandle, size, false);
			};
		}

		/// <summary>
		/// Called when a target enters a Bolas pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterBolas(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;

			var trigger = dialog.Npc;
			var caster = trigger.Vars.Get<ICombatEntity>("Melia.BolasCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.BolasSkill");

			if (trigger.DisappearTime < DateTime.Now)
				return Task.CompletedTask;

			if (caster.IsHostileFaction(initiator))
			{
				// No clue what this skill does.
			}

			return Task.CompletedTask;
		}
	}
}
