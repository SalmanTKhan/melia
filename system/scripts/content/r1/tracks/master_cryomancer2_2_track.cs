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

[TrackScript("MASTER_CRYOMANCER2_2_TRACK")]
public class MASTERCRYOMANCER22TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MASTER_CRYOMANCER2_2_TRACK");
		//SetMap("d_cmine_02");
		//CenterPos(1441.09,79.54,342.48);
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
			case 26:
				//DRT_RUN_FUNCTION("SCR_MASTER_CRYOMANCER2_2_BOSS_DEAD");
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_scroll", "A Yeti has appeared, and it's coming for you!", 3);
				break;
			case 37:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-110);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
