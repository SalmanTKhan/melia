using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Trigger chill, Cold Air Attack Damage Increase..
	/// </summary>
	[BuffHandler(BuffId.ColdDetonation)]
	public class ColdDetonation : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.Ice_Atk_BM, buff.NumArg1 * buff.NumArg3);
		}

		public override void OnEnd(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.Ice_Atk_BM, -buff.NumArg1 * buff.NumArg3);
		}
	}
}
