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

[TrackScript("FANTASYLIB485_MQ_2_TRACK")]
public class FANTASYLIB485MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB485_MQ_2_TRACK");
		//SetMap("d_fantasylibrary_48_5");
		//CenterPos(-1507.90,-0.02,-119.86);
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
			case 4:
				//DRT_PLAY_MGAME("FANTASYLIB485_MQ_2_MINI");
				character.AddonMessage("NOTICE_Dm_!", "Destroy all of the emerging Dimensional Doors!", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
