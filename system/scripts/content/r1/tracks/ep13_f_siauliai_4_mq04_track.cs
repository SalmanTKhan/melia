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

[TrackScript("EP13_F_SIAULIAI_4_MQ04_TRACK")]
public class EP13FSIAULIAI4MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_4_MQ04_TRACK");
		//SetMap("None");
		//CenterPos(824.46,79.91,518.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		return Array.Empty<IActor>();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 25:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_4_MQ04_TRACK_DLG_01", 2);
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
