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

[TrackScript("JOB_ASSASSIN_Q1_TRACK")]
public class JOBASSASSINQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_ASSASSIN_Q1_TRACK");
		//SetMap("f_rokas_25");
		//CenterPos(-2038.17,359.17,357.85);
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
				//DRT_RUN_FUNCTION("SCR_JOB_ASSASSIN_Q1_GIMMICK_SETTING");
				break;
			case 20:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
