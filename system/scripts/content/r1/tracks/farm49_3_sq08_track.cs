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

[TrackScript("FARM49_3_SQ08_TRACK")]
public class FARM493SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_3_SQ08_TRACK");
		//SetMap("f_farm_49_3");
		//CenterPos(-1191.85,245.74,1260.21);
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
				character.AddonMessage("NOTICE_Dm_scroll", "The strong scent is smeared from the flower.", 3);
				//DRT_ACTOR_PLAY_EFT("F_light058_blue", "MID", 0);
				break;
			case 31:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 33:
				character.AddonMessage("NOTICE_Dm_!", "Monsters allured by the scent of the flower appear!{nl}Defeat them!", 3);
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("FARM49_3_SQ08_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
