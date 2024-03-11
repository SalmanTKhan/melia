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

[TrackScript("JOB_SHADOWMANCER_Q1")]
public class JOBSHADOWMANCERQ1 : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_SHADOWMANCER_Q1");
		//SetMap("f_pilgrimroad_41_3");
		//CenterPos(-34.69,136.64,25.82);
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
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_Clear", "The training device has been activated!{nl}While avoiding the Chaser Cubes, gather the shadow traces and take them to the training device!", 5);
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground008", "BOT");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 33:
				//CREATE_BATTLE_BOX_INLAYER(125);
				break;
			case 34:
				//DRT_PLAY_MGAME("JOB_SHADOWMANCER_Q1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
