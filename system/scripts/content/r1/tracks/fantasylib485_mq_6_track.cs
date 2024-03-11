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

[TrackScript("FANTASYLIB485_MQ_6_TRACK")]
public class FANTASYLIB485MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB485_MQ_6_TRACK");
		//SetMap("d_fantasylibrary_48_5");
		//CenterPos(916.72,1.56,1118.73);
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
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_ground078_smoke", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_ground078_smoke", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_ground078_smoke", "BOT", 1);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light024_orange", "BOT", 0);
				break;
			case 36:
				await track.Dialog.Msg("FANTASYLIB485_MQ_6_T_1");
				break;
			case 37:
				//DRT_PLAY_FORCE(26, 1, 2, "I_force018_trail_yellow", "arrow_cast", "F_light119_yellow#Dummy_emitter", "arrow_blow", "SLOW", 100, 0.5, 0, 5, 10, 0);
				break;
			case 50:
				await track.Dialog.Msg("FANTASYLIB485_MQ_6_T_2");
				break;
			case 54:
				break;
			case 59:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_dark2", "MID");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("I_smoke026_spread_out", "MID", 0);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_spread_in030_dark", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
