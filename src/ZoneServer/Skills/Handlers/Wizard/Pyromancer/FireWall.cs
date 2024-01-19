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

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Fire Wall.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_FireWall)]
	public class FireWall : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_firewall_cast" : "voice_wiz_firewall_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_firewall_cast" : "voice_wiz_firewall_cast");
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

			Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, targetPos);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, targetPos);

			this.ExecuteFireWall(caster, skill, targetPos, wallIds);
		}


		/// <summary>
		/// Execute Fire Wall
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="wallIds"></param>
		private void ExecuteFireWall(ICombatEntity caster, Skill skill, Position position, int[] wallIds)
		{
			var direction = caster.Position.GetDirection(position).AddDegreeAngle(90);
			var packetStringId = "Pyromancer_FireWall";
			var duration = 10f;
			var size = 15f;
			for (var i = 0; i < wallIds.Length; i++)
			{
				var padHandle = wallIds[i];
				var effectPosition = position.GetRelative(direction, 70 - 20 * i);
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, effectPosition, direction, 1, 75f, padHandle, size);

				var area = new CircleF(effectPosition, size);

				var trigger = new Npc(12082, "", new Location(caster.Map.Id, effectPosition), direction);
				trigger.Vars.Set("Melia.FireWallCaster", caster);
				trigger.Vars.Set("Melia.FireWallSkill", skill);
				trigger.SetTriggerArea(area);
				trigger.SetEnterTrigger($"PYROMANCER_FIRE_WALL_ENTER_{padHandle}", this.OnEnterFireWallPad);

				trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
				caster.Map.AddMonster(trigger);

				trigger.OnDisappear += () => Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, effectPosition, direction, 1, 75f, padHandle, size, false);
			}
		}

		/// <summary>
		/// Add specific buff to a target.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void StartBuff(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.FireWall_Debuff, TimeSpan.FromSeconds(10), caster);
		}

		/// <summary>
		/// Called when a target enters a FireWall pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterFireWallPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;

			var trigger = dialog.Npc;
			var caster = trigger.Vars.Get<ICombatEntity>("Melia.FireWallCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.FireWallSkill");

			if (trigger.DisappearTime < DateTime.Now)
				return Task.CompletedTask;

			if (caster.IsHostileFaction(initiator))
			{
				this.StartBuff(caster, initiator, skill);
				trigger.DisappearTime = trigger.DisappearTime.AddSeconds(-2);
			}

			return Task.CompletedTask;
		}
	}
}
