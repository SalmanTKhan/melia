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

[TrackScript("THORN19_GATE_06")]
public class THORN19GATE06 : TrackScript
{
	protected override void Load()
	{
		SetId("THORN19_GATE_06");
		//SetMap("d_thorn_19");
		//CenterPos(2106.78,505.79,910.33);
	}


}
