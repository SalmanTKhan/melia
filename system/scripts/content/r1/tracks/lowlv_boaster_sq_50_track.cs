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

[TrackScript("LOWLV_BOASTER_SQ_50_TRACK")]
public class LOWLVBOASTERSQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LOWLV_BOASTER_SQ_50_TRACK");
		//SetMap("id_catacomb_01");
		//CenterPos(-240.16,935.69,-1145.75);
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
				character.AddonMessage("NOTICE_Dm_scroll", "Upon using the purification gem, a group of Leaf Bugs has appeared.", 7);
				break;
			case 21:
				//DRT_PLAY_MGAME("LOWLV_BOASTER_SQ_50_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
