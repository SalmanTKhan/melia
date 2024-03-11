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

[TrackScript("FTOWER45_SQ_05_TRACK")]
public class FTOWER45SQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER45_SQ_05_TRACK");
		//SetMap("d_firetower_45");
		//CenterPos(-69.13,150.03,1516.87);
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
			case 26:
				//TRACK_MON_LOOKAT();
				break;
			case 27:
				//TRACK_SETTENDENCY();
				break;
			case 28:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_!", "The Stone Whale guarding Hauberk has woken up. {nl}Defeat Stone Whale!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
