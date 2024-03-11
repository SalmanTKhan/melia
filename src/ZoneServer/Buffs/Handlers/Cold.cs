using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Chilly, Decreased movement speed..
	/// </summary>
	[BuffHandler(BuffId.Cold)]
	public class Cold : BuffHandler
	{
		private const int MovementBonus = 30;

		public override void OnStart(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.SPD_BM, -MovementBonus);
		}

		public override void OnEnd(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.SPD_BM, MovementBonus);
		}
	}
}
