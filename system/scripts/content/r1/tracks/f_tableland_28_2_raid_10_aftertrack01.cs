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

[TrackScript("F_TABLELAND_28_2_RAID_10_AFTERTRACK01")]
public class FTABLELAND282RAID10AFTERTRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("F_TABLELAND_28_2_RAID_10_AFTERTRACK01");
		//SetMap("None");
		//CenterPos(-1511.85,154.98,-580.04);
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
				await track.Dialog.Msg("F_TABLELAND_28_2_RAID_10_TRACK_DLG_02");
				break;
			case 10:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
