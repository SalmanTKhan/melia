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

[TrackScript("testabab")]
public class testabab : TrackScript
{
	protected override void Load()
	{
		SetId("testabab");
		//SetMap("None");
		//CenterPos(-0.06,0.00,-0.13);
	}


}
