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

[TrackScript("ROKAS27_MQ_1_TRACK")]
public class ROKAS27MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS27_MQ_1_TRACK");
		//SetMap("f_rokas_27");
		//CenterPos(627.80,1196.10,-2668.81);
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
				//DRT_ACTOR_ATTACH_EFFECT("I_box_dead_mash", "BOT");
				break;
			case 3:
				break;
			case 6:
				break;
			case 8:
				break;
			case 10:
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark1", "BOT");
				break;
			case 31:
				//TRACK_SETTENDENCY();
				break;
			case 32:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
