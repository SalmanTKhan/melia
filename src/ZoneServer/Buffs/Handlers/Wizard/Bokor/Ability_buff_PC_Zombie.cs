using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Monsters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Zombie, Zombie Buff.
	/// </summary>
	[BuffHandler(BuffId.Ability_buff_PC_Zombie)]
	public class Ability_buff_PC_Zombie : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			if (buff.Target is Summon summon)
				summon.Owner.StartBuff(BuffId.PowerOfDarkness_Buff, TimeSpan.FromMinutes(1), summon.Owner);
		}
		public override void WhileActive(Buff buff)
		{
			if (buff.Target is Summon summon)
				summon.Owner.StartBuff(BuffId.PowerOfDarkness_Buff, TimeSpan.FromMinutes(1), summon.Owner);
		}
	}
}
