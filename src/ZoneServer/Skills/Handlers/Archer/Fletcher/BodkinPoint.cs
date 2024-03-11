using System;
using Melia.Shared.Game.Const;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Handlers.Base;

namespace Melia.Zone.Skills.Handlers.Fletcher
{
	/// <summary>
	/// Handler for the Fletcher skill Bodkin Point.
	/// </summary>
	[SkillHandler(SkillId.Fletcher_BodkinPoint)]
	public class BodkinPoint : IPassiveSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster)
		{
			if (!skill.IsOnCooldown && !caster.IsBuffActive(BuffId.Fletcher_BodkinPoint_Buff))
				caster.StartBuff(BuffId.Fletcher_BodkinPoint_Buff, TimeSpan.Zero);
			skill.OnCooldownChanged += () => caster.StartBuff(BuffId.Fletcher_BodkinPoint_Buff, TimeSpan.Zero);
		}
	}
}
