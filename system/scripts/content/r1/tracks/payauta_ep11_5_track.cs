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

[TrackScript("PAYAUTA_EP11_5_TRACK")]
public class PAYAUTAEP115TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PAYAUTA_EP11_5_TRACK");
		//SetMap("f_castle_20_1");
		//CenterPos(-277.84,283.69,-467.03);
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
				await track.Dialog.Msg("PAYAUTA_EP11_5_TRACK_DLG_0");
				break;
			case 6:
				await track.Dialog.Msg("PAYAUTA_EP11_5_TRACK_DLG_1");
				break;
			case 7:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 10, 0);
				break;
			case 13:
				await track.Dialog.Msg("PAYAUTA_EP11_5_TRACK_DLG_2");
				break;
			case 19:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
