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
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;

namespace Melia.Zone.Skills.Handlers.Fletcher
{
	/// <summary>
	/// Handler for the Fletcher skill Catena Chain Arrow.
	/// </summary>
	[SkillHandler(SkillId.Fletcher_CatenaChainArrow)]
	public class CatenaChainArrow : IDynamicGroundSkillHandler
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
			if (skill.Vars.TryGet<int>("Melia.CatenaChainArrowPadHandle", out var padHandle))
			{
				skill.IncreaseOverheat();
				caster.SetAttackState(true);
				Send.ZC_NORMAL.UpdateSkillEffect(caster, caster.Handle, caster.Position, caster.Direction, Position.Zero);

				Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, ForceId.GetNew(), null);

				if (caster.Map.TryGetMonster(padHandle, out var monster) && monster is Npc trigger)
					trigger.DisappearTime = DateTime.Now;
				return;
			}

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

			var effectId1 = "I_force018_trail_chain#Dummy_Force";
			var effectDuration1 = TimeSpan.FromSeconds(0.4);
			var effectId2 = "F_explosion092_hit_mint";
			var effectDuration2 = TimeSpan.FromSeconds(1);
			Send.ZC_NORMAL.SkillProjectile(caster, targetPos, effectId1, effectDuration1, effectId2, effectDuration2, 0f, 0.5f, 0f, 200f);

			var forceId = ForceId.GetNew();
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, forceId, null);

			if (caster is Character character)
				Send.ZC_SEND_PC_EXPROP(character, new MsgParameter("FLETCHER_CATENA_ENABLE", 1f));
			this.ExecuteCatenaChainArrow(caster, skill, targetPos);
		}


		/// <summary>
		/// Execute Catena Chain Arrow
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="skill"></param>
		/// <param name="position"></param>
		private void ExecuteCatenaChainArrow(ICombatEntity caster, Skill skill, Position position)
		{
			var direction = caster.Direction;
			var padHandle = ZoneServer.Instance.World.CreateEffectHandle();
			var packetStringId = "Fletcher_CatenaChainArrow_PAD";
			var duration = 20f;
			var size = 20f;

			Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 0f, 92f, padHandle, size);

			var area = new CircleF(position, size);

			var trigger = new Npc(12082, "", new Location(caster.Map.Id, position), direction);
			trigger.Vars.Set("Melia.CatenaChainArrowCaster", caster);
			trigger.Vars.Set("Melia.CatenaChainArrowSkill", skill);
			trigger.SetTriggerArea(area);
			trigger.SetEnterTrigger("FLETCHER_CATENA_CHAIN_ARROW_ENTER", this.OnEnterCatenaChainArrow);

			trigger.DisappearTime = DateTime.Now.AddSeconds(duration);
			trigger.OwnerHandle = caster.Handle;
			trigger.AssociatedHandle = caster.Handle;
			caster.Map.AddMonster(trigger);

			caster.StartBuff(BuffId.Fletcher_CatenaChainArrow_Buff, TimeSpan.FromSeconds(duration), caster);
			//Can't start buff on trigger because Npcs can't be buffed.
			//trigger.StartBuff(BuffId.Fletcher_CatenaChainArrow_MonBuff, TimeSpan.FromSeconds(duration), caster);

			if (caster is Character character)
				Send.ZC_SEND_PC_EXPROP(character, new MsgParameter("FLETCHER_CATENA_ENABLE", 0f));

			skill.Vars.SetInt("Melia.CatenaChainArrowPadHandle", trigger.Handle);

			trigger.OnDisappear += () =>
			{
				Send.ZC_NORMAL.SkillPad(caster, skill, packetStringId, position, direction, 0f, 92f, padHandle, size, false);
				skill.Vars.SetInt("Melia.CatenaChainArrowPadHandle", 0);
				skill.IncreaseOverheat();
			};
		}

		/// <summary>
		/// Called when a target enters a Catena Chain Arrow pad.
		/// </summary>
		/// <param name="dialog"></param>
		/// <returns></returns>
		private Task OnEnterCatenaChainArrow(Dialog dialog)
		{
			if (dialog.Initiator is not ICombatEntity initiator)
				return Task.CompletedTask;
			if (!initiator.IsHitByPad())
				return Task.CompletedTask;

			var trigger = dialog.Npc;
			var caster = trigger.Vars.Get<ICombatEntity>("Melia.CatenaChainArrowCaster");
			var skill = trigger.Vars.Get<Skill>("Melia.CatenaChainArrowSkill");

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
