﻿using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;

namespace Melia.Zone.Buffs.Handlers.Common
{
	/// <summary>
	/// Handle for the Smite Buff, which increases the target's attack.
	/// </summary>
	[BuffHandler(BuffId.Smite_Buff)]
	public class Smite_Buff : BuffHandler
	{
		private const float AtkRateBonus = 0.10f;

		public override void OnActivate(Buff buff, ActivationType activationType)
		{
			AddPropertyModifier(buff, buff.Target, PropertyName.PATK_MAIN_RATE_BM, AtkRateBonus);
		}

		public override void OnEnd(Buff buff)
		{
			RemovePropertyModifier(buff, buff.Target, PropertyName.PATK_MAIN_RATE_BM);
		}
	}
}
