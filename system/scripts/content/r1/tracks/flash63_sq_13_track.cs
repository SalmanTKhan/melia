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

[TrackScript("FLASH63_SQ_13_TRACK")]
public class FLASH63SQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH63_SQ_13_TRACK");
		//SetMap("f_flash_63");
		//CenterPos(158.20,55.94,126.56);
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
				character.AddonMessage("NOTICE_Dm_!", "A magic circle is destroyed as an old magic stone gets unstuck!", 3);
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground", "BOT");
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_wizard_BRIQUETTING_ADD3_smoke", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow", "BOT", 0);
				break;
			case 30:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 34:
				character.AddonMessage("NOTICE_Dm_!", "Monsters head towards the destroyed magic circle!", 5);
				//DRT_PLAY_MGAME("FLASH63_SQ_13_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
