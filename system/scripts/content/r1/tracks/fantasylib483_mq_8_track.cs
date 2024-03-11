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

[TrackScript("FANTASYLIB483_MQ_8_TRACK")]
public class FANTASYLIB483MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB483_MQ_8_TRACK");
		//SetMap("d_fantasylibrary_48_3");
		//CenterPos(-945.76,149.09,2211.39);
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
				await track.Dialog.Msg("FANTASYLIB483_MQ_8_TRACK_1");
				break;
			case 21:
				break;
			case 39:
				await track.Dialog.Msg("FANTASYLIB483_MQ_8_TRACK_2");
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Templeshooter", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
