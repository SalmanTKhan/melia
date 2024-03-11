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

[TrackScript("ROKAS24_QB_8_ENDING_TRACK")]
public class ROKAS24QB8ENDINGTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS24_QB_8_ENDING_TRACK");
		//SetMap("f_rokas_26");
		//CenterPos(-499.35,724.05,-1758.07);
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
				await track.Dialog.Msg("ROKAS24_QB_8_END");
				break;
			case 23:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 26:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
