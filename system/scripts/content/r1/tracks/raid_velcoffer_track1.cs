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

[TrackScript("RAID_VELCOFFER_TRACK1")]
public class RAIDVELCOFFERTRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("RAID_VELCOFFER_TRACK1");
		//SetMap("d_raidboss_velcoffer");
		//CenterPos(2338.77,188.75,-251.96);
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
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke030", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke014", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke006", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion041_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke108", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out051", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out005_orange", "BOT");
				break;
			case 39:
				//DRT_PLAY_MGAME("RAID_VELCOPFFER_RARE_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
