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

[TrackScript("KATYN18_MQ_30_TRACK")]
public class KATYN18MQ30TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN18_MQ_30_TRACK");
		//SetMap("f_katyn_18");
		//CenterPos(-2102.75,595.05,1007.62);
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
				await track.Dialog.Msg("f_katyn_18_dlg_3");
				break;
			case 7:
				await track.Dialog.Msg("f_katyn_18_dlg_4");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_lineup015_blue", "BOT", 0);
				break;
			case 55:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
