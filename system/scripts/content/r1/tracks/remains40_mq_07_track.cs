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

[TrackScript("REMAINS40_MQ_07_TRACK")]
public class REMAINS40MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS40_MQ_07_TRACK");
		//SetMap("f_remains_40");
		//CenterPos(3659.47,645.74,2622.78);
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
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 33:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 34:
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
