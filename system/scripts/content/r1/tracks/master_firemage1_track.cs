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

[TrackScript("MASTER_FIREMAGE1_TRACK")]
public class MASTERFIREMAGE1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MASTER_FIREMAGE1_TRACK");
		//SetMap("c_voodoo");
		//CenterPos(-30.60,0.00,16.62);
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
			case 1:
				await track.Dialog.Msg("JOB_FIREMAGE_prog1");
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("I_light021_dark", "TOP", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_explosion99_dark2", "MID", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_ground071_smoke_dark", "MID", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_spread_in004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in004_dark", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				break;
			case 26:
				break;
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
