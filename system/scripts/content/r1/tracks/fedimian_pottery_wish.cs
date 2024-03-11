using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("FEDIMIAN_POTTERY_WISH")]
public class FEDIMIANPOTTERYWISH : TrackScript
{
	protected override void Load()
	{
		SetId("FEDIMIAN_POTTERY_WISH");
		//SetMap("None");
		//CenterPos(465.43,177.95,-83.31);
	}


}
