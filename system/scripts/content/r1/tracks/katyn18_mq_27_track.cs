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

[TrackScript("KATYN18_MQ_27_TRACK")]
public class KATYN18MQ27TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN18_MQ_27_TRACK");
		//CenterPos(876.38,373.19,-2086.65);
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
			case 4:
				break;
			case 8:
				await track.Dialog.Msg("f_katyn_18_dlg_2");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_ghostnpc_born", "BOT");
				break;
			case 13:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
