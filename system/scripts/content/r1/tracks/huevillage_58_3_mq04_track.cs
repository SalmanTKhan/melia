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

[TrackScript("HUEVILLAGE_58_3_MQ04_TRACK")]
public class HUEVILLAGE583MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_3_MQ04_TRACK");
		//SetMap("f_huevillage_58_3");
		//CenterPos(-1347.45,-1.37,-1275.18);
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
				//DRT_ACTOR_PLAY_EFT("F_explosion039", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_loop_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_loop_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_loop_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_loop_ground", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_burstup004_dark", "BOT", 0);
				break;
			case 28:
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_burstup004_dark", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_burstup004_dark", "BOT", 0);
				break;
			case 31:
				break;
			case 32:
				//DRT_MOVETOTGT(50);
				break;
			case 33:
				character.AddonMessage("NOTICE_Dm_!", "The effect of the bomb slows down your movement {nl} when you approach the nearby Upents!", 5);
				break;
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			case 35:
				//DRT_MOVETOTGT(50);
				break;
			case 36:
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
