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

[TrackScript("ORCHARD_34_1_SQ_12_TRACK")]
public class ORCHARD341SQ12TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_34_1_SQ_12_TRACK");
		//SetMap("f_orchard_34_1");
		//CenterPos(-368.01,0.57,1152.48);
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
				break;
			case 23:
				break;
			case 25:
				break;
			case 53:
				character.AddonMessage("NOTICE_Dm_scroll", "Monsters have started attacking each other for some reason!", 5);
				break;
			case 56:
				break;
			case 74:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion078_dark", "BOT");
				break;
			case 79:
				await track.Dialog.Msg("ORCHARD_34_1_SQ_12_TRACK_dlg1");
				break;
			case 90:
				break;
			case 91:
				break;
			case 92:
				break;
			case 93:
				break;
			case 99:
				character.AddonMessage("NOTICE_Dm_scroll", "A lot of monsters have gathered{nl}Defeat all the monsters that stand in your way!", 5);
				break;
			case 105:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
