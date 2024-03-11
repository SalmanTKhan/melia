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

[TrackScript("JOB_2_HOPLITE4_TRACK_RE")]
public class JOB2HOPLITE4TRACKRE : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_2_HOPLITE4_TRACK_RE");
		//SetMap("f_rokas_24");
		//CenterPos(817.20,123.93,-309.23);
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
			case 9:
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_smoke2", "BOT", 0);
				break;
			case 44:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Sparnasman and retrieve Aidas' Lost Spearhead!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
