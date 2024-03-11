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

[TrackScript("SIAU_EAST_TEST")]
public class SIAUEASTTEST : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU_EAST_TEST");
		//SetMap("None");
		//CenterPos(-2370.58,130.02,1255.22);
	}


}
