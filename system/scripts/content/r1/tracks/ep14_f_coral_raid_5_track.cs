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

[TrackScript("EP14_F_CORAL_RAID_5_TRACK")]
public class EP14FCORALRAID5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_F_CORAL_RAID_5_TRACK");
		//SetMap("f_coral_32_2");
		//CenterPos(1025.18,-93.63,111.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1025.176f, -93.6283f, 111.5445f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "f_coral_32_2", 1072.2, -93.6283, 106.8445, 2.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_SETPOS();
				break;
			case 12:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG1");
				break;
			case 13:
				//DRT_RUN_FUNCTION("SCR_EP14_F_CORAL_RAID_5_TRACK_DAYLIGHT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground141_light_blue_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke191_blue_loop2", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_light080_blue", "MID", 0);
				break;
			case 19:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG2");
				break;
			case 20:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG3");
				break;
			case 21:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG4");
				break;
			case 22:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG5");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_spread_out050_blue", "BOT", 0);
				break;
			case 25:
				//DRT_RUN_FUNCTION("SCR_EP14_F_CORAL_RAID_5_TRACK_CLEARDAYLIGHY");
				//DRT_CLEAR_EFFECT();
				break;
			case 28:
				await track.Dialog.Msg("EP14_F_CORAL_RAID_5_TRACK_DLG6");
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
