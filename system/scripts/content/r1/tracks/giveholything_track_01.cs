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

[TrackScript("GIVEHOLYTHING_TRACK_01")]
public class GIVEHOLYTHINGTRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("GIVEHOLYTHING_TRACK_01");
		//SetMap("c_klaipe_cathedral_medium_in");
		//CenterPos(-33.64,16.54,0.68);
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
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_lineup014_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion123_dark", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_holy_loop", "MID");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_light020_yellow", "TOP", 0);
				break;
			case 50:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle002", "TOP");
				break;
			case 72:
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "MID", 0);
				break;
			case 85:
				//DRT_ACTOR_ATTACH_EFFECT("F_light086_line_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light086_line_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light086_line_loop", "BOT");
				break;
			case 94:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force015_yellow", "skl_holylight", "F_burstup057_yellow", "skl_eff_holysmash_shot", "SLOW", 100, 0, 2000, 1, 1, 0);
				break;
			case 106:
				break;
			case 108:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				break;
			case 109:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				break;
			case 121:
				await track.Dialog.Msg("GIVEHOLYTHING_TRACK_01_DLG1");
				break;
			case 123:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup014_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion123_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "MID", 0);
				break;
			case 129:
				//TRACK_BASICLAYER_MOVE();
				//DRT_RUN_FUNCTION("GIVEHOLYTHING_END_OUT_ZONE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
