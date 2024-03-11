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

[TrackScript("PILGRIM41_5_SQ10_TRACK")]
public class PILGRIM415SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_5_SQ10_TRACK");
		//SetMap("f_pilgrimroad_41_5");
		//CenterPos(-749.48,-98.99,272.70);
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
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_lineup015_blue", "BOT", 1);
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_blue_loop", "BOT");
				break;
			case 36:
				await track.Dialog.Msg("PILGRIM415_SQ_10_succ1");
				break;
			case 38:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
