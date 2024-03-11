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

[TrackScript("M_FLIBRAY_BOSS_BEFORE_1")]
public class MFLIBRAYBOSSBEFORE1 : TrackScript
{
	protected override void Load()
	{
		SetId("M_FLIBRAY_BOSS_BEFORE_1");
		//SetMap("None");
		//CenterPos(1434.82,-8.96,699.65);
	}


}
