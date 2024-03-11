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

[TrackScript("f_3cmlake_84_flamingo")]
public class f3cmlake84flamingo : TrackScript
{
	protected override void Load()
	{
		SetId("f_3cmlake_84_flamingo");
		//SetMap("f_3cmlake_84");
		//CenterPos(111.52,272.24,-1102.32);
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
				break;
			case 4:
				break;
			case 14:
				//DRT_FUNC_UNHIDENPC("ORCHARD_32_4_FLAMINGO_TRACK_BOX");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
