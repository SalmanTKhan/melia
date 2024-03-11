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

[TrackScript("FANTASYLIB483_MQ_1_TRACK")]
public class FANTASYLIB483MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB483_MQ_1_TRACK");
		//SetMap("None");
		//CenterPos(-847.72,225.45,-654.49);
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
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder007_light_yellow", "BOT");
				break;
			case 7:
				await track.Dialog.Msg("FANTASYLIB483_MQ_1_TRACK");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder007_light_yellow", "BOT");
				break;
			case 19:
				character.AddSessionObject(PropertyName.FANTASYLIB483_MQ_1, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
