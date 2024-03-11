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

[TrackScript("F_CASTLE_97_MQ_05_TRACK")]
public class FCASTLE97MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_97_MQ_05_TRACK");
		//SetMap("f_castle_97");
		//CenterPos(1972.93,286.60,1121.92);
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
			case 12:
				await track.Dialog.Msg("F_CASTLE_97_MQ_05_TRACK_DLG1");
				break;
			case 16:
				await track.Dialog.Msg("F_CASTLE_97_MQ_05_TRACK_DLG2");
				break;
			case 21:
				await track.Dialog.Msg("F_CASTLE_97_MQ_05_TRACK_DLG3");
				break;
			case 25:
				await track.Dialog.Msg("F_CASTLE_97_MQ_05_TRACK_DLG4");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
