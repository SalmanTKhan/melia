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

[TrackScript("F_3CMLAKE_27_2_SQ_8_TRACK1")]
public class F3CMLAKE272SQ8TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_27_2_SQ_8_TRACK1");
		//SetMap("f_3cmlake_27_2");
		//CenterPos(-602.20,-92.65,534.16);
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
			case 41:
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_hit_great", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("I_SYS_missdigit", "TOP", 0);
				break;
			case 106:
				await track.Dialog.Msg("F_3CMLAKE_27_2_TRACK_DLG1");
				break;
			case 119:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
