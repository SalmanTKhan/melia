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

[TrackScript("F_3CMLAKE_87_MQ_10_TRACK")]
public class F3CMLAKE87MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_87_MQ_10_TRACK");
		//SetMap("f_3cmlake_87");
		//CenterPos(720.45,167.28,1333.42);
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
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_archer_bodkinpoint_hit_explosion#Dummy001", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize#Dummy001", "TOP", 0);
				break;
			case 24:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_10_DLG1");
				break;
			case 29:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_ADDBUFF("HPLock", 100, 0, 0, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
