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

[TrackScript("F_3CMLAKE_87_MQ_12_TRACK")]
public class F3CMLAKE87MQ12TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_87_MQ_12_TRACK");
		//SetMap("f_3cmlake_87");
		//CenterPos(-42.10,153.81,1902.92);
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
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_12_DLG1");
				break;
			case 45:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_12_DLG3");
				break;
			case 83:
				break;
			case 110:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_12_DLG5");
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 119:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 120:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 122:
				break;
			case 123:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 124:
				break;
			case 125:
				break;
			case 126:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 127:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 129:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 136:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_12_DLG6");
				break;
			case 143:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 144:
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red_1", "BOT", 0);
				break;
			case 145:
				//DRT_ACTOR_PLAY_EFT("F_spread_out029_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				break;
			case 169:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
