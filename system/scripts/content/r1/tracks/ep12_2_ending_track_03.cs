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

[TrackScript("EP12_2_ENDING_TRACK_03")]
public class EP122ENDINGTRACK03 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_03");
		//SetMap("d_dcapital_108");
		//CenterPos(475.58,23.86,1961.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(475.5779f, 23.85547f, 1961.065f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154040, "", "d_dcapital_108", 473.8421, 23.85547, 1931.377, 63.14286);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "", "d_dcapital_108", 456.3819, 23.85547, 1915.83, 53.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 489.9571, 23.85547, 1899.919, 53);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150241, "", "d_dcapital_108", 472.668, 23.85547, 2506.736, 2.020725);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151021, "UnvisibleName", "d_dcapital_108", 474.8656, 23.85547, 2507.18, 5.663265);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 476.0951, 23.85547, 2372.806, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147382, "", "d_dcapital_108", 758.8841, 23.85547, 2368.686, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151020, "", "d_dcapital_108", 472.8262, 23.85547, 2360.865, 37.72727);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 481.7586, 23.85547, 2456.483, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_dcapital_108", 506.1742, 23.85547, 2428.436, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150237, "", "d_dcapital_108", 503.4296, 23.85547, 2432.088, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147382, "", "d_dcapital_108", 646.3455, 23.85547, 2435.73, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47236, "", "d_dcapital_108", 475.0672, 23.85547, 2530.474, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150238, "", "d_dcapital_108", 473.4072, 23.85547, 2505.702, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 71:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_05");
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_yellow2", "MID", 0);
				break;
			case 95:
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2", "BOT");
				break;
			case 106:
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				break;
			case 107:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle037_dark_loop", "MID");
				//DRT_ACTOR_PLAY_EFT("F_spread_out051", "MID", 0);
				break;
			case 110:
				//DRT_ACTOR_PLAY_EFT("F_spread_out028_dark", "BOT", 0);
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("F_spread_out028_dark", "BOT", 0);
				break;
			case 112:
				//DRT_ACTOR_PLAY_EFT("F_spread_out028_dark", "BOT", 0);
				break;
			case 161:
				//DRT_ACTOR_PLAY_EFT("F_spread_in012_circle", "BOT", 0);
				break;
			case 173:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow2", "MID");
				break;
			case 191:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force015_yellow", "skl_eff_spiralarrow_cast", "I_light013_spark_yellow", "skl_holylight", "SLOW", 15, 0, 0, 0, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 235:
				break;
			case 236:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 237:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 238:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 239:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 240:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 241:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 242:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 243:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 244:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 245:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 246:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 247:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 248:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 249:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 251:
				//DRT_ACTOR_PLAY_EFT("F_explosion132_white_black", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_circle038_dark_loop", "MID");
				break;
			case 252:
				//DRT_ACTOR_PLAY_EFT("I_burst_up_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke_red2_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground196_levitation_violet_loop", "BOT");
				break;
			case 261:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_2");
				break;
			case 269:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ18_DLG_3", 3);
				break;
			case 292:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_4");
				break;
			case 293:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_5");
				break;
			case 294:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_24");
				break;
			case 302:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_6");
				break;
			case 303:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_25");
				break;
			case 304:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_7");
				break;
			case 305:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_8");
				break;
			case 306:
				//DRT_RUN_FUNCTION("SCR_EP12_2_D_DCAPITAL_108_MQ18_TRACKINSELDLG_01");
				break;
			case 311:
				//DRT_ACTOR_PLAY_EFT("I_circle004_mash", "MID", 0);
				break;
			case 316:
				//DRT_ACTOR_PLAY_EFT("I_circle004_mash", "MID", 0);
				break;
			case 321:
				//DRT_ACTOR_PLAY_EFT("I_circle004_mash", "MID", 0);
				break;
			case 322:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 328:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_10");
				break;
			case 345:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_11");
				break;
			case 346:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_12");
				break;
			case 347:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_13");
				break;
			case 360:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				break;
			case 361:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_03");
				//DRT_ACTOR_PLAY_EFT("I_light007_red", "MID", 0);
				break;
			case 366:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_26");
				break;
			case 368:
				//DRT_PLAY_FORCE(0, 1, 2, "I_light007_red", "skl_eff_rune_light", "I_light007_red", "None", "FAST", 50, 1, 0, 5, 0, 0);
				break;
			case 375:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_14");
				break;
			case 376:
				//DRT_PLAY_FORCE(0, 1, 2, "I_light004_red4", "skl_eff_rune_light", "I_light007_red", "None", "FAST", 50, 1, 0, 5, 0, 0);
				break;
			case 386:
				//DRT_RUN_FUNCTION("EP12_2_D_DCAPITAL_108_MQ_HEADONICON_01");
				break;
			case 387:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_15");
				break;
			case 388:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_05");
				break;
			case 391:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 395:
				//DRT_ACTOR_PLAY_EFT("I_smoke035_dark", "MID", 0);
				break;
			case 396:
				//DRT_ACTOR_ATTACH_EFFECT("F_dash012_yellow_loop", "BOT");
				break;
			case 397:
				//DRT_ACTOR_PLAY_EFT("I_smoke035_dark", "MID", 0);
				break;
			case 409:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 422:
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				break;
			case 428:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 429:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 430:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 431:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 432:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 433:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 434:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 435:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_SETPOS();
				break;
			case 436:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				break;
			case 437:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 438:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 439:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 440:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 441:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 444:
				//DRT_ACTOR_PLAY_EFT("F_explosion007_white2", "MID", 0);
				break;
			case 454:
				break;
			case 502:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_16");
				break;
			case 519:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_17");
				break;
			case 529:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_18");
				break;
			case 539:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_19");
				break;
			case 541:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 552:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_20");
				break;
			case 590:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ18_DLG_21", 5);
				break;
			case 596:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
