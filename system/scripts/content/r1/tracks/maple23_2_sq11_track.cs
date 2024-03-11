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

[TrackScript("MAPLE23_2_SQ11_TRACK")]
public class MAPLE232SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MAPLE23_2_SQ11_TRACK");
		//SetMap("None");
		//CenterPos(289.93,0.11,106.32);
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
				await track.Dialog.Msg("MAPLE232_SQ_11_track1");
				break;
			case 7:
				await track.Dialog.Msg("MAPLE232_SQ_11_track2");
				break;
			case 9:
				await track.Dialog.Msg("MAPLE232_SQ_11_track3");
				break;
			case 11:
				await track.Dialog.Msg("MAPLE232_SQ_11_track4");
				break;
			case 21:
				await track.Dialog.Msg("MAPLE232_SQ_11_track5");
				break;
			case 23:
				await track.Dialog.Msg("MAPLE232_SQ_11_track6");
				break;
			case 24:
				break;
			case 26:
				break;
			case 32:
				break;
			case 41:
				await track.Dialog.Msg("MAPLE232_SQ_11_track7");
				break;
			case 43:
				await track.Dialog.Msg("MAPLE232_SQ_11_track8");
				break;
			case 48:
				await track.Dialog.Msg("MAPLE232_SQ_11_track9");
				break;
			case 65:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
