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

[TrackScript("PRISON_82_MQ_11_TRACK")]
public class PRISON82MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_82_MQ_11_TRACK");
		//SetMap("d_prison_82");
		//CenterPos(-422.22,413.80,-384.06);
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
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_yellow", "BOT");
				break;
			case 32:
				await track.Dialog.Msg("PRISON_82_MQ_11_TRACK_dlg1");
				break;
			case 34:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out001_light#Dummy001", "arrow_cast", "F_cleric_ausirine_shot_light", "skl_holylight", "SLOW", 50, 1, 0, 1, 10, 0);
				break;
			case 43:
				character.AddonMessage("NOTICE_Dm_GetItem", "Obtained the Revelation of Kalejimas Prison!", 5);
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("SCR_PRISON_82_MQ_11_AFTER_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
