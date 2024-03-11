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

[TrackScript("KATYN18_SUB03_TRACK")]
public class KATYN18SUB03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN18_SUB03_TRACK");
		//CenterPos(1417.97,429.83,1320.14);
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
			case 11:
				break;
			case 14:
				//ChangeScale(0.7, 0);
				break;
			case 15:
				//ChangeScale(0.6, 0);
				//ChangeScale(0.7, 0);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
