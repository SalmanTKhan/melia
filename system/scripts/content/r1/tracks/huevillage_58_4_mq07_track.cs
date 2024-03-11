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

[TrackScript("HUEVILLAGE_58_4_MQ07_TRACK")]
public class HUEVILLAGE584MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ07_TRACK");
		//SetMap("f_huevillage_58_4");
		//CenterPos(1293.85,-22.47,-276.54);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark", "BOT");
				break;
			case 13:
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_explosiontrap_shot_smoke", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_active_smoke", "BOT");
				break;
			case 31:
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
