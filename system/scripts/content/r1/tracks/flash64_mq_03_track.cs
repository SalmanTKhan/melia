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

[TrackScript("FLASH64_MQ_03_TRACK")]
public class FLASH64MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH64_MQ_03_TRACK");
		//SetMap("f_flash_64");
		//CenterPos(-127.81,843.06,2024.61);
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
			case 46:
				break;
			case 59:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-20);
				character.AddonMessage("NOTICE_Dm_!", "Your surroundings will become quiet after you use the Silence Scroll!{nl}Defeat Gargoyle!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
