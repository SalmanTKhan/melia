using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Barbarian
{
	/// <summary>
	/// Handler for the Barbarian skill Pouncing.
	/// </summary>
	[SkillHandler(SkillId.Barbarian_Pouncing)]
	public class Pouncing : IDynamicCasted
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.SetAttackState(true);
			caster.Properties.SetFloat(PropertyName.Jumpable, 0);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_NORMAL.SkillPad(caster, skill, "Barbarian_Pouncing", caster.Position, caster.Direction, 0, 35, skillHandle, 45);
			var buff = new Buff(BuffId.Pouncing_Buff, 0, 0, TimeSpan.Zero, caster, caster);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_PLAY_SOUND(caster, "voice_war_atk_long_cast");
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			caster.Properties.SetFloat(PropertyName.Jumpable, 1);
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.Pouncing_Buff);
			if (caster is Character character)
			{
				Send.ZC_STOP_SOUND(character, "voice_war_atk_long_cast");
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 3.5f);
			}
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_NORMAL.SkillPad(caster, skill, "Barbarian_Pouncing", caster.Position, caster.Direction, 0, 35, skillHandle, 45);
		}
	}
}
