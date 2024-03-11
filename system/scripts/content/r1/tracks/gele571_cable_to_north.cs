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

[TrackScript("GELE571_CABLE_TO_NORTH")]
public class GELE571CABLETONORTH : TrackScript
{
	protected override void Load()
	{
		SetId("GELE571_CABLE_TO_NORTH");
		//SetMap("f_gele_57_1");
		//CenterPos(0.00,0.00,0.00);
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
				//AttachToBGModelNode("f_gele_57_1_right_move", "cable_randing01", 120, 0.7);
				break;
			case 5:
				//DRT_BGMODEL_ANIM("f_gele_57_1_right_move", "f_gele_57_1_right_move.xsm", 0);
				break;
			case 29:
				//DRT_BGMODEL_ANIM("f_gele_57_1_right_move", "f_gele_57_1_right_std.xsm", 0);
				//AttachToBGModelNode("None", "Dummy003", 120, 0.7);
				//DRT_JUMP_TO_POS(1, 200);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
