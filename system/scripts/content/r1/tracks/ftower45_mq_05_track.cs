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

[TrackScript("FTOWER45_MQ_05_TRACK")]
public class FTOWER45MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER45_MQ_05_TRACK");
		//SetMap("d_firetower_45");
		//CenterPos(758.14,250.37,1920.24);
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
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_red", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke023_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke041_red", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke023_red", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke041_red", "BOT");
				break;
			case 35:
				//DRT_MOVETOTGT(50);
				break;
			case 37:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat Helgasercle, who is occupying the Mage Tower!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
