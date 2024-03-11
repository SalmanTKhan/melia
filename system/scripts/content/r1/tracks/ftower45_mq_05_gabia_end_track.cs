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

[TrackScript("FTOWER45_MQ_05_GABIA_END_TRACK")]
public class FTOWER45MQ05GABIAENDTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER45_MQ_05_GABIA_END_TRACK");
		//SetMap("d_firetower_45");
		//CenterPos(839.33,254.17,2290.11);
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
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light009_yellow", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "MID");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground051_loop", "BOT");
				break;
			case 35:
				await track.Dialog.Msg("FTOWER45_MQ_07_track");
				break;
			case 43:
				break;
			case 46:
				break;
			case 49:
				break;
			case 52:
				break;
			case 80:
				break;
			case 91:
				//DRT_ACTOR_ATTACH_EFFECT("I_spell_crystal_gem_red_parts_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup007_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle016", "BOT");
				break;
			case 92:
				//DRT_ACTOR_ATTACH_EFFECT("I_spell_crystal_gem_red_parts_mash", "BOT");
				break;
			case 118:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_resurrection_shot", "BOT");
				break;
			case 119:
				await track.Dialog.Msg("FTOWER45_MQ_06_track");
				break;
			case 124:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_blue", "BOT");
				break;
			case 132:
				await track.Dialog.Msg("FTOWER45_MQ_06_prog");
				break;
			case 153:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
