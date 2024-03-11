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

[TrackScript("FLASH61_SQ_11_1_TRACK")]
public class FLASH61SQ111TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH61_SQ_11_1_TRACK");
		//SetMap("f_flash_61");
		//CenterPos(-1036.93,511.16,153.44);
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
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_icon", "MID");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ironskin_shot_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ironskin_shot_ground", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ironskin_shot_ground", "BOT");
				break;
			case 23:
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("I_spin006", "BOT");
				break;
			case 50:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion001_dark", "BOT");
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion001_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion001_dark", "BOT");
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("I_spin005", "BOT");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("I_spin005", "BOT");
				break;
			case 62:
				//DRT_ACTOR_ATTACH_EFFECT("F_light016", "BOT");
				break;
			case 69:
				await track.Dialog.Msg("f_flash_61_track_dlg_2");
				break;
			case 70:
				character.AddonMessage("NOTICE_Dm_!", "Lepus appeared by crossing over the time!{nl}Defeat Lepus!", 3);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
