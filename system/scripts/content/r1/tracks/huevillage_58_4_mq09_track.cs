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

[TrackScript("HUEVILLAGE_58_4_MQ09_TRACK")]
public class HUEVILLAGE584MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ09_TRACK");
		//SetMap("d_thorn_20");
		//CenterPos(2597.05,488.86,743.20);
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
				await track.Dialog.Msg("HUEVILLAGE_58_4_MQ09_BLACK_MAN_1");
				break;
			case 3:
				break;
			case 11:
				await track.Dialog.Msg("HUEVILLAGE_58_4_MQ09_BLACK_MAN_2");
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
