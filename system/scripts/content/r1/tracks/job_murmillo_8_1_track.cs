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

[TrackScript("JOB_MURMILLO_8_1_TRACK")]
public class JOBMURMILLO81TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_MURMILLO_8_1_TRACK");
		//SetMap("f_katyn_45_1");
		//CenterPos(72.36,200.31,940.43);
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
			case 6:
				character.AddonMessage("NOTICE_Dm_scroll", "You have found the Silva Griffin that the Murmillo Master was talking about!", 3);
				break;
			case 22:
				//TRACK_SETTENDENCY();
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the Silva Griffin and prove your skills", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
