using System;
using Melia.Shared.Tos.Const;
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
		private bool _applyPowerOfDarknessBuff;
		public override void OnStart(Buff buff)
		{
			if (buff.Caster is Summon summon)
			{
				_applyPowerOfDarknessBuff = summon.Owner.IsBuffActive(BuffId.Ability_buff_PC_Zombie);
				summon.Owner.StopBuff(BuffId.Ability_buff_PC_Zombie);
			}
		}

		public override void WhileActive(Buff buff)
		{
			if (buff.Caster is Summon summon && _applyPowerOfDarknessBuff)
			{
				summon.Owner.StartBuff(BuffId.PowerOfDarkness_Buff, TimeSpan.FromMinutes(1), summon.Owner);
			}
		}
	}
}
