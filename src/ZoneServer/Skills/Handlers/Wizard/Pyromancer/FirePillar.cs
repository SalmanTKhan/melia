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

namespace Melia.Zone.Skills.Handlers.Pyromancer
{
	/// <summary>
	/// Handler for the Pyromancer skill Fire Pillar.
	/// </summary>
	[SkillHandler(SkillId.Pyromancer_FirePillar)]
	public class FirePillar : IDynamicGroundSkillHandler
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

			var targets = caster.Map.GetAttackableEntitiesInRange(caster, targetPos, (int)skill.Data.SplashRange * 4);
			var damageDelay = TimeSpan.FromMilliseconds(200);

			var hits = new List<SkillHitInfo>();

			foreach (var currentTarget in targets.LimitBySDR(caster, skill))
			{
				var skillHitResult = SCR_SkillHit(caster, currentTarget, skill);
				currentTarget.TakeDamage(skillHitResult.Damage, caster);

				var skillHit = new SkillHitInfo(caster, currentTarget, skill, skillHitResult, damageDelay, TimeSpan.Zero);
				hits.Add(skillHit);
			}

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, targetPos, hits);

			this.ExecuteFirePillar(caster, targetPos, skill);
		}

		/// <summary>
		/// Execute Fire Pillar
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void ExecuteFirePillar(ICombatEntity caster, Position targetPos, Skill skill)
		{
			var position = targetPos;
			var direction = caster.Direction;
			var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "Wizard_New_FirePillar10";
			var size = 50f;
			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1f, 62.63292f, effectHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.FirePillarCaster", caster);
			trigger.Vars.Set("Melia.FirePillarSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("PYROMANCER_FIRE_PILLAR_ENTER", this.OnEnterFirePillarPad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(10);
			caster.Map.AddMonster(trigger);

			trigger.OnDisappear += () => Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 1f, 62.63292f, effectHandle, size, false);
		}

		/// <summary>
		/// Burns a target directly with a buff.
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void BuffFirePillar(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			target.StartBuff(BuffId.FirePillar_Debuff, 0, 0, TimeSpan.FromSeconds(10), caster);
		}

		/// <summary>
		/// Called when a target enters a fire pillar pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterFirePillarPad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;

			if (initiator.IsBuffActive(BuffId.FirePillar_Debuff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.FirePillarCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.FirePillarSkill");

			if (caster.IsHostileFaction(initiator))
				this.BuffFirePillar(caster, initiator, skill);

			return Task.CompletedTask;
		}
	}
}
