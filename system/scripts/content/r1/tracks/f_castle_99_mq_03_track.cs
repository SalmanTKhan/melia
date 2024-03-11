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

[TrackScript("F_CASTLE_99_MQ_03_TRACK")]
public class FCASTLE99MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_99_MQ_03_TRACK");
		//SetMap("f_castle_99");
		//CenterPos(649.88,-131.12,987.40);
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
			case 14:
				//DRT_FUNC_ACT("SCR_F_CASTLE_99_MQ_03_SETTING");
				break;
			case 33:
				Send.ZC_NORMAL.Notice(character, "F_CASTLE_99_MQ_03_DLG_PRE", 10);
				break;
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("F_CASTLE_99_MQ_03_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
