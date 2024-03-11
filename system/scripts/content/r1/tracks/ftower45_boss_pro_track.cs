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

[TrackScript("FTOWER45_BOSS_PRO_TRACK")]
public class FTOWER45BOSSPROTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER45_BOSS_PRO_TRACK");
		//SetMap("d_firetower_45");
		//CenterPos(-1254.50,228.92,-1704.02);
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
				//DRT_ACTOR_PLAY_EFT("reaction_fire", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_pc_standthrow_sfread_out", "BOT", 0);
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
