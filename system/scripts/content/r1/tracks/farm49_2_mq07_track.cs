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

[TrackScript("FARM49_2_MQ07_TRACK")]
public class FARM492MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_2_MQ07_TRACK");
		//SetMap("f_farm_49_2");
		//CenterPos(-527.77,65.11,900.03);
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
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 1);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("I_light013_spark_blue_2", "MID", 0);
				break;
			case 11:
				await track.Dialog.Msg("FARM49_2_MQ_07_2");
				break;
			case 13:
				await track.Dialog.Msg("FARM49_2_MQ_07_3");
				break;
			case 14:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
