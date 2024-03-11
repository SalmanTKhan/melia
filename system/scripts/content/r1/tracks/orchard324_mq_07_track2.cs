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

[TrackScript("ORCHARD324_MQ_07_TRACK2")]
public class ORCHARD324MQ07TRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD324_MQ_07_TRACK2");
		//SetMap("mission_groundtower_1");
		//CenterPos(141.85,239.70,334.27);
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
			case 10:
				break;
			case 22:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_01");
				break;
			case 24:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_02");
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				break;
			case 27:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_03");
				break;
			case 29:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_04");
				break;
			case 33:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_05");
				break;
			case 39:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_06");
				break;
			case 41:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_07");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_rize006_red", "BOT", 0);
				break;
			case 49:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_08");
				break;
			case 62:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_09");
				break;
			case 64:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
