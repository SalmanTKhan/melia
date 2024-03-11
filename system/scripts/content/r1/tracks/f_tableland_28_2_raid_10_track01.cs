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

[TrackScript("F_TABLELAND_28_2_RAID_10_TRACK01")]
public class FTABLELAND282RAID10TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("F_TABLELAND_28_2_RAID_10_TRACK01");
		//SetMap("None");
		//CenterPos(-1539.05,154.98,-552.82);
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
			case 24:
				await track.Dialog.Msg("F_TABLELAND_28_2_RAID_10_TRACK_DLG_01");
				break;
			case 29:
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_light033_circle_blue", "MID", 0);
				break;
			case 34:
				break;
			case 47:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("F_TABLELAND_28_2_RAID_10_MINI01");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
