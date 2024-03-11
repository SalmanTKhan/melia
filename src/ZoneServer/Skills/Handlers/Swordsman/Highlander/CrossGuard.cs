using System;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Highlander
{
	/// <summary>
	/// Handler for the Highlander skill Cross Guard.
	/// </summary>
	[SkillHandler(SkillId.Highlander_CrossGuard)]
	public class CrossGuard : IDynamicGroundSkillHandler
	{
		public void StartDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			Send.ZC_PLAY_SOUND(caster, "shieldup", 0, -1, 0);
			Send.ZC_PLAY_SOUND(caster, "shieldup_2", 0, -1, 0);
			var buff = new Buff(BuffId.CrossGuard_Buff, 0, 0, TimeSpan.FromSeconds(0), caster, caster);
			//buff.Skill = skill;
			caster?.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastStart(character, skill.Id);
		}

		public void EndDynamicCast(Skill skill, ICombatEntity caster, float maxCastTime)
		{
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.StartUp_Charging_Buff);
			if (caster is Character character)
				Send.ZC_NORMAL.Skill_DynamicCastEnd(character, skill.Id, 2);
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			skill.IncreaseOverheat();
		}
	}
}
