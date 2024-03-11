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

[TrackScript("PRISON621_MQ_06_TRACK")]
public class PRISON621MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON621_MQ_06_TRACK");
		//SetMap("d_prison_62_1");
		//CenterPos(499.85,430.99,698.45);
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
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_ADD3_smoke_yellow", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_ADD3_smoke_yellow", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_ADD3_smoke_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_ADD3_smoke_yellow", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_1inchpunch_cast_smoke_yellow", "BOT");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in023_green", "BOT");
				break;
			case 62:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern012_ground_loop", "BOT");
				break;
			case 69:
				character.AddSessionObject(PropertyName.PRISON621_MQ_06, 1);
				character.AddonMessage("NOTICE_Dm_Clear", "An unknown sacred power is bursting inside the body!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
