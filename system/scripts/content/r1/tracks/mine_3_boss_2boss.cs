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

[TrackScript("MINE_3_BOSS_2boss")]
public class MINE3BOSS2boss : TrackScript
{
	protected override void Load()
	{
		SetId("MINE_3_BOSS_2boss");
		//SetMap("d_cmine_6");
		//CenterPos(2116.47,56.93,1725.82);
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
			case 27:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "MID");
				break;
			case 41:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out001_light", "holyark_loop", "F_ground012_light", "skl_holylight", "SLOW", 50, 1, 100, 1, 0, 0);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				character.AddSessionObject(PropertyName.CMINE6_TO_KATYN7_1, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
