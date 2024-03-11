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

[TrackScript("SHADOWMANCER_UNIQUE_TRACK01")]
public class SHADOWMANCERUNIQUETRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("SHADOWMANCER_UNIQUE_TRACK01");
		//SetMap("shadow_raid_main");
		//CenterPos(2668.71,28.51,-1180.81);
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
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_wizard_teleportation_shot", "BOT", 0);
				break;
			case 9:
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_archer_explosiontrap_shot_smoke", "TOP", 1);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_archer_explosiontrap_shot_smoke", "TOP", 1);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue_dark", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue_dark", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue_dark", "BOT", 0);
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue_dark", "BOT", 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_ground026_rize", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground093_dark", "MID", 0);
				break;
			case 87:
				//DRT_RUN_FUNCTION("SCR_SHADOW_RAID_TRACK_01_USER_END");
				break;
			case 88:
				character.Tracks.End(this.TrackId);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
