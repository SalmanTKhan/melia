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

[TrackScript("rain_mission")]
public class rainmission : TrackScript
{
	protected override void Load()
	{
		SetId("rain_mission");
		//SetMap("None");
		//CenterPos(17.20,249.46,-1390.51);
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
			case 21:
				break;
			case 25:
				break;
			case 27:
				break;
			case 41:
				break;
			case 43:
				break;
			case 44:
				break;
			case 57:
				break;
			case 59:
				break;
			case 60:
				break;
			case 66:
				break;
			case 69:
				break;
			case 72:
				break;
			case 75:
				break;
			case 97:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
