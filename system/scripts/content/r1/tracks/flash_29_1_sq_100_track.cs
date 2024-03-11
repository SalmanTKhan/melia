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

[TrackScript("FLASH_29_1_SQ_100_TRACK")]
public class FLASH291SQ100TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_29_1_SQ_100_TRACK");
		//SetMap("f_flash_29_1");
		//CenterPos(-1313.63,201.22,293.31);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_light094_blue_loop", "BOT");
				break;
			case 4:
				Send.ZC_NORMAL.Notice(character, "FLASH29_1_SQ_100_OBJ2_DLG1", 5);
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_light073_yellow_loop", "TOP");
				break;
			case 50:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 54:
				character.AddonMessage("NOTICE_Dm_!", "Monsters have sensed the magic energy. Prepare for the wave!{nl}", 5);
				//DRT_PLAY_MGAME("FLASH_29_1_SQ_100_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
