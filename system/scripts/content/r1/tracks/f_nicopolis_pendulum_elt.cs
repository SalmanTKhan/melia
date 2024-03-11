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

[TrackScript("f_nicopolis_pendulum_elt")]
public class fnicopolispendulumelt : TrackScript
{
	protected override void Load()
	{
		SetId("f_nicopolis_pendulum_elt");
		//SetMap("None");
		//CenterPos(0.00,0.00,0.00);
	}


}
