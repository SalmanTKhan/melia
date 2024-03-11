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

[TrackScript("SIAU15_R_MQ_08_TRACK")]
public class SIAU15RMQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU15_R_MQ_08_TRACK");
		//SetMap("f_siauliai_15_re");
		//CenterPos(-2318.13,741.86,-157.18);
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
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ghostnpc_born", "BOT");
				break;
			case 20:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_15");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 1);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 1);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 1);
				break;
			case 33:
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 1);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 1);
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_ghostnpc_born", "BOT");
				break;
			case 39:
				break;
			case 48:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_16");
				break;
			case 83:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
