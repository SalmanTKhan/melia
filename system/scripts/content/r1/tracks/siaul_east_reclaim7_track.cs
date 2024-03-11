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

[TrackScript("SIAUL_EAST_RECLAIM7_TRACK")]
public class SIAULEASTRECLAIM7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAUL_EAST_RECLAIM7_TRACK");
		//SetMap("f_siauliai_2");
		//CenterPos(452.28,130.91,-852.25);
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
				break;
			case 5:
				//TRACK_SETTENDENCY();
				break;
			case 14:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-30);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
