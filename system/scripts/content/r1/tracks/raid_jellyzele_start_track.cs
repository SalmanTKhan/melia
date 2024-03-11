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

[TrackScript("raid_jellyzele_start_track")]
public class raidjellyzelestarttrack : TrackScript
{
	protected override void Load()
	{
		SetId("raid_jellyzele_start_track");
		//SetMap("None");
		//CenterPos(1126.70,0.50,1540.92);
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
			case 16:
				//DRT_CAM_ZOOM_NEW(100, 0, 0);
				break;
			case 17:
				//DRT_CAM_ZOOM_NEW(300, 10, 1);
				break;
			case 64:
				//DRT_CAM_ZOOM_NEW(0, 0, 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
