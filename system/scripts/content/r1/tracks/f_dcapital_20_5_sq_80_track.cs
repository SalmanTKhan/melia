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

[TrackScript("F_DCAPITAL_20_5_SQ_80_TRACK")]
public class FDCAPITAL205SQ80TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_DCAPITAL_20_5_SQ_80_TRACK");
		//SetMap("f_dcapital_20_5");
		//CenterPos(490.00,-16.50,379.95);
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
			case 1:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_smoke065", "BOT", 0);
				break;
			case 36:
				break;
			case 37:
				break;
			case 38:
				break;
			case 39:
				break;
			case 40:
				break;
			case 43:
				character.AddonMessage("NOTICE_Dm_scroll", "A demon has disappeared with what looked like the mark of the goddess!", 7);
				break;
			case 44:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
