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

[TrackScript("EP14_1_RAID_PREVIEW_TRACK")]
public class EP141RAIDPREVIEWTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_RAID_PREVIEW_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(-1649.79,180.75,-70.58);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1650.981f, 180.7452f, -71.05502f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151021, "", "ep14_1_f_castle_5", -2755.673, 181.0452, -48.8124, 0.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2485.931, 181.0452, 64.74877, 97);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2526.496, 181.0452, -89.91245, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2442.484, 181.0452, -87.02107, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2420.792, 181.0452, -146.313, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2453.563, 181.0452, -32.71968, 186);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2548.993, 181.0452, 80.76969, 186);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2452.597, 181.0452, 22.04782, 186);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2528.397, 181.0452, -39.65004, 186);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2483.369, 181.0452, -143.9514, 186);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2516.661, 181.0452, 22.44757, 186);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2733.984, 181.0452, -127.2299, 67.5);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2322.554, 181.0452, -68.04248, 39.52381);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2270.725, 181.0452, 1.87727, 42.85714);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2265.626, 181.0452, -148.4001, 57.14286);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2348.324, 181.0452, 82.5471, 49.28572);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2330.87, 181.0452, -202.7553, 21.66667);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2729.187, 181.0452, 46.17056, 64.61539);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2596.956, 181.0452, 30.01296, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2636.455, 181.0452, -127.3996, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2567.317, 181.0452, -126.9182, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2663.601, 181.0452, -59.86495, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2659.382, 181.0452, 47.34239, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2617.325, 181.0452, -21.42648, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_5", -2588.964, 181.0452, -66.91568, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2340.524, 181.0452, -126.9649, 1020);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2340.524, 181.0452, -126.9649, 685);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2340.524, 181.0452, -126.9649, 845);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2340.524, 181.0452, -126.9649, 260);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", -2340.524, 181.0452, -126.9649, 1465);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 150287, "", "ep14_1_f_castle_5", -1522.496, 180.7451, 8.399574, 0);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 154120, "", "ep14_1_f_castle_5", -1472.89, 180.7451, -51.39518, 0);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 4:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 5:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 6:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 7:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 1500, 5, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 18:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 19:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				break;
			case 20:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force018_trail_fire_2", "skl_eff_forge_shot", "F_explosion098_dark_red", "boom_shot", "FAST", 400, 0, 2500, 5, 0, 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_spread_out017_circle_red2", "BOT", 0);
				break;
			case 35:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_9_TRACK_DLG1");
				break;
			case 41:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_9_TRACK_DLG2");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
