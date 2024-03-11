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

[TrackScript("LOWLV_EYEOFBAIGA_SQ_60_TRACK")]
public class LOWLVEYEOFBAIGASQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LOWLV_EYEOFBAIGA_SQ_60_TRACK");
		//SetMap("None");
		//CenterPos(569.58,346.15,1405.33);
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
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "MID");
				break;
			case 19:
				character.AddonMessage("NOTICE_Dm_scroll", "A Gazing Golem has appeared.", 7);
				break;
			case 24:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
