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

[TrackScript("KATYN_45_2_SQ_13_TRACK")]
public class KATYN452SQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_45_2_SQ_13_TRACK");
		//SetMap("f_katyn_45_2");
		//CenterPos(291.75,165.73,1645.38);
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
			case 5:
				break;
			case 6:
				//CREATE_BATTLE_BOX_INLAYER(-100);
				break;
			case 21:
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_scroll", "A Sequoia that had been circling the area has appeared", 3);
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
