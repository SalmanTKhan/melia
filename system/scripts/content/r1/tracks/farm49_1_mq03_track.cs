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

[TrackScript("FARM49_1_MQ03_TRACK")]
public class FARM491MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_1_MQ03_TRACK");
		//SetMap("None");
		//CenterPos(1772.58,254.84,993.42);
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
				//DRT_ACTOR_PLAY_EFT("F_cleric_Revival_light", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 31:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
