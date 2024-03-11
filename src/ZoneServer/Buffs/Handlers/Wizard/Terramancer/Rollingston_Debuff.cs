using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Rolling Stone, Rolling Stone.
	/// </summary>
	[BuffHandler(BuffId.Rollingston_Debuff)]
	public class Rollingston_Debuff : BuffHandler
	{
		private const string VarName = "Melia.MSPDPenalty";
		private const float MSPDPenalty = -10;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			buff.Vars.SetFloat(VarName, MSPDPenalty);

			target.Properties.Modify(PropertyName.MSPD_BM, MSPDPenalty);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			if (buff.Vars.TryGetFloat(VarName, out var penalty))
				target.Properties.Modify(PropertyName.MSPD_BM, -penalty);
		}
	}
}
