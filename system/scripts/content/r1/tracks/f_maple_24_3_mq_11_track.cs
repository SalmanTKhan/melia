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

[TrackScript("F_MAPLE_24_3_MQ_11_TRACK")]
public class FMAPLE243MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_11_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(-1464.77,0.70,-882.85);
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
				//DRT_ACTOR_PLAY_EFT("F_spread_in012_blue", "MID", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_cleric_dodola_line", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "MID", 0);
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_light115_explosion_blue3", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin023", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light066_yellow_loop", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 37:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_11_TRACK_DLG1");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_light008_2", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
