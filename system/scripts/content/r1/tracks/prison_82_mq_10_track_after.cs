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

[TrackScript("PRISON_82_MQ_10_TRACK_AFTER")]
public class PRISON82MQ10TRACKAFTER : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_82_MQ_10_TRACK_AFTER");
		//SetMap("d_prison_82");
		//CenterPos(-515.84,618.94,-1518.04);
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
				//DRT_ACTOR_PLAY_EFT("F_hit003_light_mint", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 24:
				break;
			case 28:
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("I_sys_caution_UI", "TOP", 0);
				break;
			case 37:
				await track.Dialog.Msg("PRISON_82_MQ_10_BOSS_DLG");
				break;
			case 38:
				await track.Dialog.Msg("PRISON_82_MQ_10_BLACKMAN_01");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke143_dark_red_loop", "BOT");
				break;
			case 41:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red", "arrow_cast", "F_light126_red_2", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				break;
			case 74:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
