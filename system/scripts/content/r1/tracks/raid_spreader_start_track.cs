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

[TrackScript("Raid_Spreader_Start_Track")]
public class RaidSpreaderStartTrack : TrackScript
{
	protected override void Load()
	{
		SetId("Raid_Spreader_Start_Track");
		//SetMap("raid_castle_ep14_2");
		//CenterPos(-24.08,0.50,-306.37);
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
			case 2:
				//DRT_CAM_ZOOM_NEW(80, 0, 0);
				break;
			case 3:
				//DRT_CAM_ZOOM_NEW(130, 30, 1);
				break;
			case 4:
				break;
			case 33:
				//DRT_CAM_ZOOM_NEW(130, 10, 1);
				break;
			case 55:
				//DRT_CAM_ZOOM_NEW(0, 0, 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
