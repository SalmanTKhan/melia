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

[TrackScript("JOB_ONMYOJI_Q1_TRACK")]
public class JOBONMYOJIQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_ONMYOJI_Q1_TRACK");
		//SetMap("f_tableland_72");
		//CenterPos(481.21,374.31,-100.02);
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
			case 12:
				//DRT_RUN_FUNCTION("SCR_JOB_ONMYOJI_Q1_GIMMICK_WALL_SETTING");
				break;
			case 24:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//DRT_RUN_FUNCTION("SCR_JOB_ONMYOJI_Q1_GIMMICK_MON_SETTING");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
