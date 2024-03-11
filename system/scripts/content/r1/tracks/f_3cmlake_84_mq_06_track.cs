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

[TrackScript("F_3CMLAKE_84_MQ_06_TRACK")]
public class F3CMLAKE84MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_84_MQ_06_TRACK");
		//SetMap("f_3cmlake_84");
		//CenterPos(635.44,263.09,-236.34);
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
				//DisableBornAni();
				break;
			case 19:
				break;
			case 73:
				character.AddonMessage("NOTICE_Dm_!", "It seems that the Hydra is furious!{nl}Defeat Hydra!", 6);
				break;
			case 85:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
