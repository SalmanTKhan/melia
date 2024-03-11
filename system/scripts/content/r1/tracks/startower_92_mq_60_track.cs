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

[TrackScript("STARTOWER_92_MQ_60_TRACK")]
public class STARTOWER92MQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_92_MQ_60_TRACK");
		//SetMap("d_startower_92");
		//CenterPos(-1417.10,725.52,1401.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1417.104f, 725.5228f, 1401.808f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20026, "", "d_startower_92", -1431.41, 725.8419, 1402.442, 24.8);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47234, "", "d_startower_92", -1435.93, 670.77, 1280.44, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "d_startower_92", -1477.082, 677.5408, 1302.279, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20079, "", "d_startower_92", -1477.08, 677.54, 1302.28, 0);
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
			case 1:
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 7:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK_STONE_ATTACH");
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 19:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK_STONE_DETACH");
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_ground051_blue", "BOT", 0);
				break;
			case 39:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK_STONE_DETACH");
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("I_d_chapel_57_7_ground_mash", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in012_blue", "BOT", 0);
				break;
			case 60:
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_light060", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_ground012_light", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground051_loop2", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_ground_incenseburner_loop", "BOT");
				break;
			case 88:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK_ATTACH");
				break;
			case 99:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 100:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK_DETACH");
				//DRT_ACTOR_ATTACH_EFFECT("F_light070_loop_event", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "BOT");
				break;
			case 105:
				await track.Dialog.Msg("STARTOWER_92_MQ_60_TRACK_DLG1");
				break;
			case 110:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("F_warrior_SpecialForceFormation_pose_light", "BOT", 0);
				break;
			case 119:
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_yellow", "TOP");
				break;
			case 145:
				//DRT_ACTOR_PLAY_EFT("F_bg_light010_yellow_long2", "BOT", 0);
				break;
			case 146:
				//DRT_ACTOR_PLAY_EFT("I_spread_out001_light2", "TOP", 0);
				break;
			case 148:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_60_TRACK");
				break;
			case 149:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
