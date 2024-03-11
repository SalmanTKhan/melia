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

[TrackScript("ROKAS26_SUB_Q10_TRACK")]
public class ROKAS26SUBQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS26_SUB_Q10_TRACK");
		//SetMap("f_rokas_26");
		//CenterPos(-1141.61,2168.34,1420.35);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
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
