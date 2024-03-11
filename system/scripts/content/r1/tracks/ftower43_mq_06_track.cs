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

[TrackScript("FTOWER43_MQ_06_TRACK")]
public class FTOWER43MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER43_MQ_06_TRACK");
		//SetMap("d_firetower_43");
		//CenterPos(1226.18,424.30,-781.67);
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
			case 5:
				await track.Dialog.Msg("FTOWER43_MQ_06_TRACK_01");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("I_wizard_backmasking_mash", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("I_firetower_gateopen_dead_mash", "BOT");
				break;
			case 46:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
