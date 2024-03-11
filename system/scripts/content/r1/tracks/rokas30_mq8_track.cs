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

[TrackScript("ROKAS30_MQ8_TRACK")]
public class ROKAS30MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS30_MQ8_TRACK");
		//SetMap("f_rokas_30");
		//CenterPos(-1358.61,212.42,-582.37);
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
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark_loop", "BOT");
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_smoke005_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
