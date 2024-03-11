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

[TrackScript("GELE572_MQ_09_TRACK")]
public class GELE572MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE572_MQ_09_TRACK");
		//SetMap("f_gele_57_2");
		//CenterPos(-1108.37,462.37,218.99);
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
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke1", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke1", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke1", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke1", "BOT", 0);
				break;
			case 10:
				//TRACK_MON_LOOKAT();
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Mushcaria and obtain its mane filled with spirits!", 5);
				break;
			case 19:
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
