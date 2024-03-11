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

[TrackScript("F_NICOPOLIS_81_2_SQ_06_TRACK")]
public class FNICOPOLIS812SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_2_SQ_06_TRACK");
		//SetMap("f_nicopolis_81_2");
		//CenterPos(-618.00,38.17,-971.99);
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
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_blue_loop", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_ground017", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground017", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground017", "BOT", 0);
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_levitation005_dark_red3", "BOT", 0);
				break;
			case 102:
				break;
			case 134:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
