using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Elementalist
{
	/// <summary>
	/// Handler for the Elementalist skill Hail.
	/// </summary>
	[SkillHandler(SkillId.Elementalist_Hail)]
	public class Hail : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(caster, character.Gender == Gender.Male ? "voice_wiz_m_hail_cast" : "voice_wiz_hail_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_hail_cast" : "voice_wiz_hail_cast");
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

			this.ExecuteHail(caster, targetPos, skill);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="position"></param>
		/// <param name="skill"></param>
		private void ExecuteHail(ICombatEntity caster, Position position, Skill skill)
		{
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			Send.ZC_NORMAL.SkillPad(caster, skill, "Elementalist_Hail", position, caster.Direction, -0.1532966f, 105.4346f, effectHandle, 10);

			var area = new CircleF(position, 50);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), caster.Direction);
			trigger.Vars.Set("Melia.HailCaster", caster);
			trigger.Vars.Set("Melia.HailSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetWhileInsideTrigger("ELEMENTALIST_HAIL_ENTER", this.OnEnterHailPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(10);
			caster.Map.AddMonster(trigger);

			this.ShowHail(caster, position, TimeSpan.Zero);
			//this.ShowHail(caster, position, TimeSpan.FromSeconds(0.2));

			Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, "Elementalist_Hail", position, caster.Direction, -0.1532966f, 105.4346f, effectHandle, 10, false));
		}

		private async Task ShowHail(ICombatEntity caster, Position position, TimeSpan delay)
		{
			for (var i = 0; i < 10; i++)
			{
				Send.ZC_NORMAL.SkillFallingProjectile(caster, "Elementalist_Hail", "I_wizard_hail_force", 0.5f, "F_wizard_hail_hit_ice", 0.5f, position.GetRandomInRange2D(0, 50), 40, delay + TimeSpan.FromSeconds(i + 0f), 0.6f, 200, 2, 0);
				Send.ZC_NORMAL.SkillFallingProjectile(caster, "Elementalist_Hail", "I_wizard_hail_force", 0.5f, "F_wizard_hail_hit_ice", 0.5f, position.GetRandomInRange2D(0, 50), 40, delay + TimeSpan.FromSeconds(i + 0.5f), 0.6f, 200, 2, 0);
				Send.ZC_NORMAL.SkillFallingProjectile(caster, "Elementalist_Hail", "I_wizard_hail_force", 0.5f, "F_wizard_hail_hit_ice", 0.5f, position.GetRandomInRange2D(0, 50), 40, delay + TimeSpan.FromSeconds(i + 1.0f), 0.6f, 200, 2, 0);
			}

			await Task.CompletedTask;
		}

		/// <summary>
		/// Burns a target directly with a buff.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void TakeDamage(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, skill, skillHitResult.Damage, skillHitResult.Result);
			hit.ForceId = ForceId.GetNew();
			Send.ZC_HIT_INFO(hit.Attacker, hit.Target, hit);
		}

		/// <summary>
		/// Called when a target enters a fire pillar pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterHailPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.HailCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.HailSkill");

			if (caster.IsHostileFaction(initiator) && !initiator.IsDead)
				this.TakeDamage(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
