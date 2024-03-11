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

[TrackScript("GLACIER_RAID_TUTO_RP_TRACK")]
public class GLACIERRAIDTUTORPTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GLACIER_RAID_TUTO_RP_TRACK");
		//SetMap("f_tableland_28_2");
		//CenterPos(-1381.12,208.30,1262.25);
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
			case 19:
				await track.Dialog.Msg("GLACIER_TUTO_RP_TRACK_DLG_01");
				break;
			case 34:
				//DRT_PLAY_MGAME("GLACIER_TUTO_RP_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
