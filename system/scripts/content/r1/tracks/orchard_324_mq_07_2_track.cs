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

[TrackScript("ORCHARD_324_MQ_07_2_TRACK")]
public class ORCHARD324MQ072TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_324_MQ_07_2_TRACK");
		//SetMap("track_underfortress_59_2");
		//CenterPos(-140.94,0.38,-808.99);
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
			case 9:
				break;
			case 40:
				break;
			case 51:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_01");
				break;
			case 62:
				break;
			case 67:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_03");
				break;
			case 74:
				break;
			case 81:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_05");
				break;
			case 104:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_11");
				break;
			case 112:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 113:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion065_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 120:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_13");
				break;
			case 124:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_14");
				break;
			case 140:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground_loop2", "TOP");
				break;
			case 141:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground_loop", "TOP");
				break;
			case 150:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_16");
				break;
			case 154:
				await track.Dialog.Msg("ORCHARD324_MQ_07_TRACK2_17");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
