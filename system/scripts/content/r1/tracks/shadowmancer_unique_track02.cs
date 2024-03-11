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

[TrackScript("SHADOWMANCER_UNIQUE_TRACK02")]
public class SHADOWMANCERUNIQUETRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("SHADOWMANCER_UNIQUE_TRACK02");
		//SetMap("shadow_raid_main");
		//CenterPos(2650.43,28.51,-1110.74);
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
			case 6:
				//DRT_ACTOR_PLAY_EFT("I_sphere011_mash", "BOT", 0);
				break;
			case 9:
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_HoleOfDarkness", "TOP");
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("I_sphere011_mash", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_spark011_orange", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_spark011_orange", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spark011_orange", "MID");
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("I_sphere011_mash", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("I_light013_spark_orange_2", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_spark011_orange", "TOP");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_spark011_orange", "TOP");
				break;
			case 29:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_seal_cage_dead", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_CannonShot_explosion_orange#Dummy_ROOT", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_punish_shot_ground_burstup", "TOP");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_BombardmentOrdeads_shot", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_Algiz_shot", "TOP");
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
