using System;
using Melia.Shared.L10N;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.BlossomBlader
{
	/// <summary>
	/// Handler for the BlossomBlader skill Start Up.
	/// </summary>
	[SkillHandler(SkillId.BlossomBlader_StartUp)]
	public class StartUp : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			var buff = new Buff(BuffId.StartUp_Charging_Buff, 0, 0, TimeSpan.FromSeconds(0), caster, caster);
			//buff.Skill = skill;
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			if (caster is Character character)
			{
				Send.ZC_PLAY_SOUND(caster, character.Gender == Gender.Male ? "voice_war_m_startup_cast" : "voice_war_f_startup_cast", 0, -1, 0);
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
			}
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.StartUp_Charging_Buff);
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, character.Gender == Gender.Male ? "voice_war_m_startup_cast" : "voice_war_f_startup_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 2);
				Send.ZC_SKILL_DISABLE(caster);
			}
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			//Send.ZC_NORMAL.Skill(caster, skill, 600625, farPos, caster.Direction, 0.06292176f, 85.76556f, skillHandle, 60);

			var buff = new Buff(BuffId.StartUp_Buff, 0, 0, TimeSpan.FromSeconds(20), caster, caster);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, TimeSpan.FromMilliseconds(300));

			//Send.ZC_SKILL_RANGE_CIRCLE(caster, originPos, 50);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);
		}
	}
}
