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

[TrackScript("KEPA_TEST")]
public class KEPATEST : TrackScript
{
	protected override void Load()
	{
		SetId("KEPA_TEST");
		//CenterPos(-65.569763,154.311844,-674.934753);
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
			case 3:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_pc_standthrow_fire", "MID", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_pc_standthrow_fire##4", "MID", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_pc_standthrow_fire##4", "MID", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_quest_bomb", "MID", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_quest_bomb", "MID", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_quest_bomb", "MID", 0);
				break;
			case 43:
				//DRT_PLAY_MGAME("KEPA_TEST_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
