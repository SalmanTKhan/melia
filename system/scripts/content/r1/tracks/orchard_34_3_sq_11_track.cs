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

[TrackScript("ORCHARD_34_3_SQ_11_TRACK")]
public class ORCHARD343SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_34_3_SQ_11_TRACK");
		//SetMap("f_orchard_34_3");
		//CenterPos(-1739.20,170.08,-386.30);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_boss_pistol_ground", "MID");
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_ground043_lineup", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_ground036_violet", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic026_pink_line", "BOT");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion074_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground149_lineup_red", "BOT");
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_explosion074_violet", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_red", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_smoke018", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "MID");
				//DRT_ACTOR_PLAY_EFT("F_archer_explosiontrap_shot_smoke", "BOT", 0);
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground040", "BOT");
				break;
			case 64:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "The Kurmis turned into a monster - defeat it!", 5);
				//DRT_ACTOR_PLAY_EFT("F_burstup008_smoke2", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
