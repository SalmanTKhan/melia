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

[TrackScript("BRACKEN42_1_SQ03_TRACK")]
public class BRACKEN421SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN42_1_SQ03_TRACK");
		//SetMap("f_bracken_42_1");
		//CenterPos(665.44,611.15,408.99);
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
			case 10:
				CreateBattleBoxInLayer(character, track);
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//DRT_PLAY_MGAME("BRACKEN42_1_SQ03_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
