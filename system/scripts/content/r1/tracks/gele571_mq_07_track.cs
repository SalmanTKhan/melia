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

[TrackScript("GELE571_MQ_07_TRACK")]
public class GELE571MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE571_MQ_07_TRACK");
		//SetMap("f_gele_57_1");
		//CenterPos(979.14,257.55,983.22);
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
			case 16:
				character.AddonMessage("NOTICE_Dm_scroll", "The Baby Pantos are returning to Capria", 3);
				break;
			case 51:
				character.AddonMessage("NOTICE_Dm_!", "It seems that Capria is upset!{nl}Give up the plan and defeat Capria!", 5);
				break;
			case 59:
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
