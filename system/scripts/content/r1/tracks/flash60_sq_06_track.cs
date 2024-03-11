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

[TrackScript("FLASH60_SQ_06_TRACK")]
public class FLASH60SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH60_SQ_06_TRACK");
		//SetMap("f_flash_60");
		//CenterPos(-696.34,193.31,-875.51);
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
			case 5:
				//DRT_ACTOR_PLAY_EFT("I_smoke014", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("I_smoke014", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("I_smoke014", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_smoke014", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_spread_in006_dark", "BOT", 0);
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_!", "Defeat the attacking Glackuman!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
