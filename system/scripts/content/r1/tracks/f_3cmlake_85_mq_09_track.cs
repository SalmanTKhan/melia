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

[TrackScript("F_3CMLAKE_85_MQ_09_TRACK")]
public class F3CMLAKE85MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_85_MQ_09_TRACK");
		//SetMap("f_3cmlake_85");
		//CenterPos(-58.82,427.52,1317.15);
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
			case 20:
				await track.Dialog.Msg("F_3CMLAKE_85_MQ_09_DLG1");
				break;
			case 31:
				break;
			case 55:
				await track.Dialog.Msg("F_3CMLAKE_85_MQ_09_DLG2");
				break;
			case 99:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "You've found the Hydra!{nl}Use the bag of purified water in combat!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
