using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP13_2_DPRISON2_MQ_7_TRACK_1")]
public class EP132DPRISON2MQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON2_MQ_7_TRACK_1");
		//SetMap("ep13_2_d_prison_2");
		//CenterPos(-1077.00,546.48,-137.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 157112, "", "ep13_2_d_prison_2", -1066.83, 546.4807, -70.96355, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1080.58f, 546.4807f, -132.8635f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_2", -1118.698, 546.4807, -77.39342, 15);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1617.49, 546.8257, 876.7558, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1725.502, 546.8257, 702.8127, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1509.359, 546.8257, 776.4917, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1493.459, 546.8257, 885.2505, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1759.983, 423.5669, -969.1492, 200);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1590.191, 423.5669, -952.9616, 60);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1668.072, 423.5669, -1104.119, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 157113, "", "ep13_2_d_prison_2", -1538.968, 423.5669, -1090.756, 150);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1717.221, 546.8257, 696.7672, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1611.427, 546.8257, 868.7572, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1490.269, 546.8257, 879.6786, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1504.648, 546.8257, 770.5364, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1801.3, 418.5557, -1015.868, 3.098592);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1719.122, 418.5556, -1155.108, 4.084507);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1640.178, 423.5669, -1008.338, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1585.279, 418.5557, -1142.063, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 147469, "", "ep13_2_d_prison_2", -1063.286, 546.4807, -74.06754, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 11:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_7_TRACK_DLG1");
				break;
			case 15:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ1_TRACK_HEADICON_1");
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_light115_explosion_blue2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_light013_spark_blue", "BOT", 0);
				break;
			case 34:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion007_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 200, 0, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion004_blue", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_blue", "arrow_blow", "FAST", 300, 0, 250, 0, 0, 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke139_blue", "BOT", 0);
				break;
			case 81:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_7_TRACK_DLG2");
				break;
			case 84:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON2_MQ_7_TRACK_DLG3", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
