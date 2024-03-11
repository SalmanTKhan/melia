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

[TrackScript("JOB_FALCONER_8_1_TRACK")]
public class JOBFALCONER81TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_FALCONER_8_1_TRACK");
		//SetMap("f_bracken_42_1");
		//CenterPos(-737.93,436.49,871.01);
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
			case 15:
				character.AddonMessage("NOTICE_Dm_scroll", "You have found the Gosal that the Falconer Master was talking about!", 5);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
