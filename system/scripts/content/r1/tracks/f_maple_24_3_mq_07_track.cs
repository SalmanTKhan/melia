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

[TrackScript("F_MAPLE_24_3_MQ_07_TRACK")]
public class FMAPLE243MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_07_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(-876.34,0.70,-1058.97);
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
			case 36:
				//DRT_PLAY_MGAME("F_MAPLE_24_3_MQ_07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
