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

[TrackScript("JOB_DOPPELSOELDNER_6_1_TRACK")]
public class JOBDOPPELSOELDNER61TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_DOPPELSOELDNER_6_1_TRACK");
		//SetMap("f_pilgrimroad_36_2");
		//CenterPos(1167.47,119.56,-385.13);
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
			case 19:
				character.AddonMessage("NOTICE_Dm_!", "The delegates were sieged by the Werewolf{nl}Defeat Werewolf!", 5);
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
