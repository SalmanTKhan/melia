using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("JOB_WIPYCRY5_1_TRACK")]
public class JOBWIPYCRY51TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_WIPYCRY5_1_TRACK");
		//SetMap("None");
		//CenterPos(-2355.03,130.02,1274.39);
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
			case 29:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}