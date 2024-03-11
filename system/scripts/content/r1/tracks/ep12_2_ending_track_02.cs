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

[TrackScript("EP12_2_ENDING_TRACK_02")]
public class EP122ENDINGTRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_02");
		//SetMap("d_dcapital_108");
		//CenterPos(474.23,23.86,1992.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(473.6429f, 23.85547f, 1991.859f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150241, "", "d_dcapital_108", 473.5348, 23.85547, 2085.393, 7.234043);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47269, "", "d_dcapital_108", 471.7305, 23.85547, 1840.882, 3.809524);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154040, "", "d_dcapital_108", 474.9097, 23.85547, 1931.506, 2.777778);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 673.1963, 23.85547, 2301.033, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 341.9476, 23.85547, 2281.309, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 580.727, 23.85547, 2289.675, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 521.7333, 23.85547, 2359.457, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 560.3705, 23.85547, 2415.576, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 294.5812, 23.85547, 2415.074, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 637.2814, 23.85547, 2238.195, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 579.2177, 23.85547, 2346.548, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 255.7903, 23.85547, 2313.135, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 371.6403, 23.85547, 2426.439, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 426.3069, 23.85547, 2359.101, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 335.4346, 23.85547, 2350.721, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 260.3183, 23.85547, 2228.749, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 643.1944, 23.85547, 2374.894, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 474.7516, 23.85547, 2424.035, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150215, "UnvisibleName", "d_dcapital_108", 475.9049, 23.85547, 2015.261, 1.283784);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 150240, "UnvisibleName", "d_dcapital_108", 455.6021, 23.85547, 1851.743, 12.08333);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 150212, "UnvisibleName", "d_dcapital_108", 474.9539, 23.85547, 1819.273, 25.71429);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 415.2018, 23.85547, 2042.597, 230);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 533.774, 23.85547, 2044.784, 120);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 501.4312, 23.85547, 2079.836, 140);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "d_dcapital_108", 444.9449, 23.85547, 2078.267, 350);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_explosion024_rize", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_spread_in001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark2", "MID", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_explosion099_dark", "BOT", 0);
				break;
			case 34:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_SET");
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_05");
				//DRT_ACTOR_PLAY_EFT("F_rize006_red ", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 46:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_5");
				break;
			case 47:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_6");
				break;
			case 48:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_7");
				break;
			case 49:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_8");
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 57:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_9");
				break;
			case 58:
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in007_dark", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				break;
			case 89:
				break;
			case 92:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ17_DLG_7", 3);
				break;
			case 96:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 97:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 98:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_CLEAR");
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 99:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_item_drop_line_loop_white", "BOT");
				//DRT_ACTOR_PLAY_EFT("I_harfsphere002_blue", "BOT", 0);
				break;
			case 100:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 101:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 102:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 103:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 104:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 105:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 106:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 107:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 108:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 109:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 110:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 111:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 112:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 113:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 114:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_ACTOR_PLAY_EFT("I_harfsphere002_blue", "BOT", 0);
				break;
			case 115:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_atk_move_l_13", "F_explosion099_dark", "skl_eff_dark_hit", "FAST", 300, 1, 0, 10, 0, 0);
				break;
			case 139:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke034_white", "skl_eff_whitetigerhowling_cast", "F_ground012_light", "skl_holylight", "FAST", 50, 1, 0, 1, 0, 0);
				break;
			case 150:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_10");
				break;
			case 151:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 156:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 161:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_1");
				break;
			case 162:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_2");
				break;
			case 163:
				//DRT_ACTOR_ATTACH_EFFECT("F_light003_yellow", "MID");
				break;
			case 165:
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 167:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_3");
				break;
			case 179:
				//DRT_PLAY_MGAME("EP12_2_ENDING_MINI_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
