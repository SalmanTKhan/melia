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

[TrackScript("MAPLE_25_2_SQ_60_TRACK")]
public class MAPLE252SQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MAPLE_25_2_SQ_60_TRACK");
		//SetMap("f_maple_25_2");
		//CenterPos(1163.13,169.09,-893.83);
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
			case 8:
				break;
			case 9:
				break;
			case 10:
				break;
			case 11:
				break;
			case 13:
				//CREATE_BATTLE_BOX_INLAYER(-100);
				break;
			case 17:
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_scroll", "More monsters are appearing", 5);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
