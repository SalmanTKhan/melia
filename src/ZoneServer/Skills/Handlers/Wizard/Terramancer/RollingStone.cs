using System;
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
using Melia.Zone.World.Actors.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.TerraMancer
{
	/// <summary>
	/// Handler for the TerraMancer skill Rolling Stone.
	/// </summary>
	[SkillHandler(SkillId.TerraMancer_RollingStone)]
	public class RollingStone : IDynamicCasted
	{
		private int _skillHandle;
		private bool _rollingStoneExists;
		private readonly string _effectName = "TerraMancer_RollingStone_DamagePad";

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

			Send.ZC_NORMAL.SkillPad(caster, skill, _effectName, caster.Position.GetRelative(caster.Direction, 35), caster.Direction, 0, 32f, _skillHandle, 35f);
			Send.ZC_DELAYED_ROTATE_MOVE_START(caster, 0.3f, 0.3f, 5.001f);

			caster.StartBuff(BuffId.Rollingston_Debuff, TimeSpan.FromSeconds(5));
			caster.StartBuff(BuffId.IS_Channeling_Buff, TimeSpan.FromSeconds(3));

			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(character, character.Gender == Gender.Male ? "voice_wiz_m_rollingstone_cast" : "voice_wiz_f_rollingstone_cast");
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}

			this.ExecuteRollingStone(caster, skill);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			Send.ZC_NORMAL.SkillPad(caster, skill, _effectName, caster.Position, caster.Direction, -0.2594702f, 62.63292f, _skillHandle, 50, false);
			Send.ZC_DELAYED_ROTATE_MOVE_END(caster);

			caster.StopBuff(BuffId.Rollingston_Debuff);
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
		/// <param name="skill"></param>
		private void ExecuteRollingStone(ICombatEntity caster, Skill skill)
		{
			var position = caster.Position;
			var direction = caster.Direction;
			var stonePosition = position.GetRelative(direction, 35);
			_rollingStoneExists = true;

			var area = new CircleF(stonePosition, 50);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, stonePosition), direction);
			trigger.Vars.Set("Melia.RollingStoneCaster", caster);
			trigger.Vars.Set("Melia.RollingStoneSkill", skill);
			trigger.SetTriggerArea(area, true);
			trigger.SetEnterTrigger("TERRAMANCER_ROLLING_STONE_ENTER", this.OnEnterRollingStonePad);

			trigger.DisappearTime = DateTime.Now.AddSeconds(5);

			caster.Map.AddMonster(trigger);
			if (!caster.Components.Has<ActorPositionUpdaterComponent>())
				caster.Components.Add(new ActorPositionUpdaterComponent(caster));
			caster.Components.Get<ActorPositionUpdaterComponent>()?.AttachActor(trigger, 35);

			Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(_ =>
			{
				caster.Components.Get<ActorPositionUpdaterComponent>()?.RemoveActor(trigger);
			});
		}

		/// <summary>
		/// Called when a target enters a rolling stone pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterRollingStonePad(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;

			if (!_rollingStoneExists)
				return Task.CompletedTask;

			var trigger = dialog.Npc;

			var caster = trigger.Vars.Get<ICombatEntity>("Melia.RollingStoneCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.RollingStoneSkill");

			if (caster.IsHostileFaction(initiator))
			{
				_rollingStoneExists = false;
				Send.ZC_NORMAL.CancelDynamicCast(caster);
				trigger.DisappearTime = DateTime.Now;

				var skillHitResult = SCR_SkillHit(caster, initiator, skill);
				initiator.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, initiator, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.AdditionalHitCount = 6;

				Send.ZC_HIT_INFO(caster, initiator, hitInfo);
			}

			return Task.CompletedTask;
		}
	}
}
