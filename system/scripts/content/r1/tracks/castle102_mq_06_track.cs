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

[TrackScript("CASTLE102_MQ_06_TRACK")]
public class CASTLE102MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE102_MQ_06_TRACK");
		//SetMap("shadow_raid_mini_dungeon");
		//CenterPos(-125.02,2.67,140.73);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-125.0204f, 2.669106f, 140.7258f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151041, "", "shadow_raid_mini_dungeon", -138, 2, 189, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154086, "", "shadow_raid_mini_dungeon", -99, 2, 189, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154102, "", "shadow_raid_mini_dungeon", -168.8961, 2.669106, 159.1495, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "shadow_raid_mini_dungeon", -149.6662, 2.669106, 150.2222, 246.6667);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG02");
				break;
			case 11:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG03");
				break;
			case 15:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG04");
				break;
			case 19:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG05");
				break;
			case 36:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG06");
				break;
			case 41:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG07");
				break;
			case 47:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG08");
				break;
			case 52:
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("I_force080_green_blue5", "MID", 0);
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground2_white", "BOT");
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_white", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light059_event", "BOT", 0);
				break;
			case 73:
				await track.Dialog.Msg("CASTLE102_MQ_06_DLG09");
				break;
			case 79:
				//DRT_FUNC_ACT("SCR_CASTLE102_MQ_06_TRACK_END");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
