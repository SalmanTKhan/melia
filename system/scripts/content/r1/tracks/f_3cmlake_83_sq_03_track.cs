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

[TrackScript("F_3CMLAKE_83_SQ_03_TRACK")]
public class F3CMLAKE83SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_83_SQ_03_TRACK");
		//SetMap("f_3cmlake_83");
		//CenterPos(-1590.84,321.05,574.80);
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
			case 32:
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_drop_water004##2", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_drop_water003##2", "BOT");
				break;
			case 41:
				break;
			case 42:
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("I_ground008_water", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 53:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 54:
				character.AddonMessage("NOTICE_Dm_!", "Rocksodon is attacking from under the water!", 3);
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 59:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_run_water", "TOP");
				break;
			case 64:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
