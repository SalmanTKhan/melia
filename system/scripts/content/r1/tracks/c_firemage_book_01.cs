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

[TrackScript("c_firemage_book_01")]
public class cfiremagebook01 : TrackScript
{
	protected override void Load()
	{
		SetId("c_firemage_book_01");
		//SetMap("None");
		//CenterPos(3.75,6.96,-3.36);
	}


}
