using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("KATYN_10_MQ_03_TRACK")]
public class KATYN10MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_10_MQ_03_TRACK");
		//SetMap("f_katyn_10");
		//CenterPos(2464.74,201.97,-468.78);
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
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation007_red", "BOT");
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_!", "The Owl Sculpture is asking for help!", 5);
				break;
			case 19:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}