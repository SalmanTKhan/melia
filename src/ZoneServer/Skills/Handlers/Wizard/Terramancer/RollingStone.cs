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
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Rolling Stone.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_RollingStone)]
	public class RollingStone : IDynamicCasted
	{
		private int _skillHandle;
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			_skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_NORMAL.SkillPad(caster, skill, "TerraMancer_RollingStone_DamagePad", caster.Position, caster.Direction, 0, 32f, _skillHandle, 35f);
			Send.ZC_DELAYED_ROTATE_MOVE_START(caster, 0.3f, 0.3f, 5.001f);

			caster.StartBuff(BuffId.Rollingston_Debuff, TimeSpan.FromSeconds(5));
			caster.StartBuff(BuffId.IS_Channeling_Buff, TimeSpan.FromSeconds(3));

			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_rollingstone_cast" : "voice_wiz_f_rollingstone_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			caster.StopBuff(BuffId.Rollingston_Debuff);

			Send.ZC_NORMAL.SkillPad(caster, skill, "TerraMancer_RollingStone_DamagePad", caster.Position, caster.Direction, 0, 32f, _skillHandle, 35f, false);
			Send.ZC_DELAYED_ROTATE_MOVE_END(caster);

			caster.StopBuff(BuffId.IS_Channeling_Buff);

			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_rollingstone_cast" : "voice_wiz_f_rollingstone_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, maxCastTime);
			}
		}

		/// <summary>
		/// Execute Rolling Stone
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		private void ExecuteRollingStone(ICombatEntity caster, ICombatEntity target, Skill skill)
		{
			var position = caster.Position;
			var direction = caster.Direction;
			var effectName = "TerraMancer_RollingStone_DamagePad";
			Send.ZC_NORMAL.SkillPad(caster, skill, effectName, caster.Position, caster.Direction, 0, 32f, _skillHandle, 35);

			var area = new CircleF(position, 50);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, caster.Position), caster.Direction);
			trigger.Vars.Set("Melia.RollingStoneCaster", caster);
			trigger.Vars.Set("Melia.RollingStoneSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("TERRAMANCER_ROLLING_STONE_ENTER", this.OnEnterRollingStonePad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(10);
			caster.Map.AddMonster(trigger);

			Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ => Send.ZC_NORMAL.SkillPad(caster, skill, effectName, caster.Position, caster.Direction, -0.2594702f, 62.63292f, _skillHandle, 50, false));
		}

		/// <summary>
		/// Called when a target enters a fire pillar pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterRollingStonePad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;

			if (initiator.IsBuffActive(BuffId.FirePillar_Debuff))
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.FirePillarCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.FirePillarSkill");

			if (caster.IsHostileFaction(initiator))
			{
				// TODO: Do damage.
			}

			return Task.CompletedTask;
		}
	}
}
