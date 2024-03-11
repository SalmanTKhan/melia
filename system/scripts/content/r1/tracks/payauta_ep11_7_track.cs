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

[TrackScript("PAYAUTA_EP11_7_TRACK")]
public class PAYAUTAEP117TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PAYAUTA_EP11_7_TRACK");
		//SetMap("f_castle_20_1");
		//CenterPos(-149.25,-0.00,446.74);
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
			case 7:
				await track.Dialog.Msg("PAYAUTA_EP11_7_TRACK_DLG_1");
				break;
			case 8:
				//DRT_PLAY_MGAME("PAYAUTA_EP11_7_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
