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

[TrackScript("MAPLE_25_1_SQ_110_TRACK")]
public class MAPLE251SQ110TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MAPLE_25_1_SQ_110_TRACK");
		//SetMap("f_maple_25_1");
		//CenterPos(1088.12,-213.53,379.32);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke045_spread_in_loop", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground093_dark", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_spread_out01_leaf", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground037_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_scroll", "A Velorchard appeared from the boulder", 5);
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin037", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out026_leaf", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground076_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire003_green", "BOT");
				break;
			case 39:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
