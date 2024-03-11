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

[TrackScript("PRISON621_MQ_05_TRACK")]
public class PRISON621MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON621_MQ_05_TRACK");
		//SetMap("d_prison_62_1");
		//CenterPos(1948.23,199.73,626.03);
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
			case 11:
				break;
			case 22:
				character.AddonMessage("NOTICE_Dm_!", "Clymen has appeared!", 8);
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			case 32:
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke068_dark", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
