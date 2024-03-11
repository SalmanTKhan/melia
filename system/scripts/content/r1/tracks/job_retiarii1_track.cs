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

[TrackScript("JOB_RETIARII1_TRACK")]
public class JOBRETIARII1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_RETIARII1_TRACK");
		//SetMap("f_farm_47_1");
		//CenterPos(-1229.73,-41.22,-235.59);
	}


}
