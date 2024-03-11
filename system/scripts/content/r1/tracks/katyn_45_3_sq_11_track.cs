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

[TrackScript("KATYN_45_3_SQ_11_TRACK")]
public class KATYN453SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_45_3_SQ_11_TRACK");
		//SetMap("f_katyn_45_3");
		//CenterPos(-406.33,35.20,15.32);
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
				break;
			case 5:
				break;
			case 16:
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_light074_yellow", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light074_yellow", "MID");
				break;
			case 33:
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground011_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle016_rainbow", "MID");
				break;
			case 40:
				//SetFixAnim("down");
				break;
			case 63:
				//DRT_FUNC_ACT("SCR_KATYN_45_3_SQ_2_FADEOUT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
