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

[TrackScript("PRISON_82_MQ_2_TRACK")]
public class PRISON82MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_82_MQ_2_TRACK");
		//SetMap("d_prison_82");
		//CenterPos(467.84,1231.04,-1420.34);
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
			case 38:
				character.AddonMessage("NOTICE_Dm_scroll", "It's exuding a power much stronger than the other demon barriers!", 4);
				break;
			case 59:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
