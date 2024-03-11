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

[TrackScript("F_3CMLAKE_84_MQ_02_TRACK")]
public class F3CMLAKE84MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_84_MQ_02_TRACK");
		//SetMap("f_3cmlake_84");
		//CenterPos(-1334.96,269.35,-467.31);
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
			case 51:
				character.AddonMessage("NOTICE_Dm_!", "The Hydra ran away as soon as the villagers rushed in", 3);
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 60:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
