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

[TrackScript("ORCHARD_324_MQ_07_TRACK")]
public class ORCHARD324MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_324_MQ_07_TRACK");
		//SetMap("f_orchard_34_2");
		//CenterPos(-1410.57,1032.38,1152.60);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke024_blue1", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_blue", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_blue", "MID");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground051_loop", "BOT");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 29:
				character.AddSessionObject(PropertyName.ORCHARD_324_MQ_07, 1);
				break;
			case 30:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
