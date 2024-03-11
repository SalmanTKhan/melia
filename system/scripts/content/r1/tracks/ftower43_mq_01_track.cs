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

[TrackScript("FTOWER43_MQ_01_TRACK")]
public class FTOWER43MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER43_MQ_01_TRACK");
		//SetMap("d_firetower_43");
		//CenterPos(-2527.46,525.34,-190.20);
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
			case 7:
				await track.Dialog.Msg("FTOWER43_MQ_01_TRACK_01");
				break;
			case 8:
				break;
			case 9:
				break;
			case 10:
				break;
			case 12:
				break;
			case 13:
				break;
			case 15:
				break;
			case 18:
				break;
			case 21:
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat all the Red Infrorocktor summoned by Antares!", 5);
				break;
			case 31:
				//DRT_MOVETOTGT(50);
				break;
			case 32:
				//DRT_MOVETOTGT(50);
				break;
			case 33:
				//DRT_MOVETOTGT(50);
				break;
			case 34:
				//DRT_MOVETOTGT(50);
				break;
			case 36:
				//DRT_MOVETOTGT(50);
				break;
			case 38:
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
