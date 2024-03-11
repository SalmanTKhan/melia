using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Sacrifice: Skeleton Archer, Critical Rate Increase.
	/// </summary>
	[BuffHandler(BuffId.Disinter_Archer_Buff)]
	public class Disinter_Archer_Buff : BuffHandler
	{
		private const string VarName = "Melia.CriticalAttackModifier";
		private const float Bonus = 1.00f;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;
			var criticalRate = target.Properties.GetFloat(PropertyName.CRTATK);

			buff.Vars.SetFloat(VarName, criticalRate * Bonus);

			target.Properties.Modify(PropertyName.CRTATK_BM, criticalRate * Bonus);
			target.Properties.Invalidate(PropertyName.CRTATK);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			if (buff.Vars.TryGetFloat(VarName, out var crtMod))
			{
				target.Properties.Modify(PropertyName.CRTATK_BM, -crtMod);
				target.Properties.Invalidate(PropertyName.CRTATK);
			}
		}
	}
}
