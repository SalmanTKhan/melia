using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Sand Wall.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_SandWall)]
	public class SandWall : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_firepillar_cast" : "voice_wiz_firepillar_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_firepillar_cast" : "voice_wiz_firepillar_cast");
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

			skill.IncreaseOverheat();
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, targetPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, caster.Position);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, targetPos);

			this.ExecuteSandWall(caster, designatedTarget, skill);
		}

		/// <summary>
		/// Execute Sand Wall
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void ExecuteSandWall(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			var position = caster.Position;
			var direction = caster.Direction;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "TerraMancer_SandWall";
			var duration = 5;
			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, -0.2594702f, 62.63292f, effectHandle, 50);

			var area = new CircleF(position, 50);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, caster.Position), caster.Direction);
			trigger.Vars.Set("Melia.SandWallCaster", caster);
			trigger.Vars.Set("Melia.SandWallSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("TERRAMANCER_SAND_WALL_ENTER", this.OnEnterSandWallPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			caster.Map.AddMonster(trigger);

			Task.Delay(TimeSpan.FromSeconds(duration))
				.ContinueWith(_ =>
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, -0.2594702f, 62.63292f, effectHandle, 50, false));
		}

		/// <summary>
		/// Slows a target directly with a buff.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void BuffSandWall(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.SandWall_Debuff, skill.Level, 0, TimeSpan.FromSeconds(3), caster);
		}

		/// <summary>
		/// Called when a target enters a sand wall pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterSandWallPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;

			if (initiator.IsBuffActive(BuffId.SandWall_Debuff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.SandWallCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.SandWallSkill");

			if (caster.IsHostileFaction(initiator))
				this.BuffSandWall(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
