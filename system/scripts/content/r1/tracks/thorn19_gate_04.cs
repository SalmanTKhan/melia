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

[TrackScript("THORN19_GATE_04")]
public class THORN19GATE04 : TrackScript
{
	protected override void Load()
	{
		SetId("THORN19_GATE_04");
		//SetMap("d_thorn_19");
		//CenterPos(207.01,618.00,1228.74);
	}


}
