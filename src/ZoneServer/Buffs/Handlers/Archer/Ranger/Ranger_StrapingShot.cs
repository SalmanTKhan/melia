using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Strafe, Strafe Available Duration.
	/// </summary>
	[BuffHandler(BuffId.Ranger_StrapingShot)]
	public class Ranger_StrapingShot : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			if (buff.Target is Character character)
				Send.ZC_SEND_PC_EXPROP(character, new MsgParameter("Ranger_StrapingShot", 1f));
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Target is Character character)
				Send.ZC_SEND_PC_EXPROP(character, new MsgParameter("Ranger_StrapingShot", 0f));
		}
	}
}
