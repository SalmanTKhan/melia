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

[TrackScript("F_DCAPITAL_20_6_SQ_20_TRACK")]
public class FDCAPITAL206SQ20TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_DCAPITAL_20_6_SQ_20_TRACK");
		//SetMap("None");
		//CenterPos(-338.20,89.01,770.89);
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
			case 3:
				break;
			case 28:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_20_BOSS1");
				break;
			case 39:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_20_BOSS2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
