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

[TrackScript("CASTLE102_MQ_05_TRACK")]
public class CASTLE102MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE102_MQ_05_TRACK");
		//SetMap("f_castle_102");
		//CenterPos(-1080.89,52.90,565.52);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150215, "", "f_castle_102", -1090.85, 52.90469, 669.7462, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1067.581f, 52.90469f, 563.288f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1088.078, 52.90468, 620.0183, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20041, "", "f_castle_102", -1088.08, 52.9, 620.02, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153092, "", "f_castle_102", -1113.8, 52.9, 635.88, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1143.795, 52.90469, 531.2457, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1131.449, 52.90468, 507.6009, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1120.915, 52.90469, 524.5522, 0.4887218);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1109.889, 52.90468, 500.1553, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1084.259, 52.90468, 523.7502, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1061.024, 52.90468, 503.6559, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1056.506, 52.90468, 527.8856, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1042.427, 52.90468, 511.4115, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47234, "", "f_castle_102", -1034.096, 52.90469, 536.1271, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 102.5);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 117.5);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 91.25);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 113.75);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 81.25);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 108.75);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 82.5);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 108.75);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1083.83, 53, 588.94, 88.75);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 154086, "", "f_castle_102", -1093, 53, 547.01, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 151041, "", "f_castle_102", -1139.332, 52.90469, 554.4557, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 154102, "", "f_castle_102", -1049.522, 52.90469, 589.2685, 0);
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
			case 6:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG02");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop2", "BOT");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_white", "BOT", 0);
				break;
			case 30:
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_light018_yellow", "TOP", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "TOP", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 51:
				break;
			case 59:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG03");
				break;
			case 60:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_04_TRACK_DAYLIGHT_SET1");
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_ground043_lineup", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup022_red2", "BOT", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("I_spread_out010_dark", "BOT", 0);
				break;
			case 72:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 78:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG04");
				break;
			case 87:
				//DRT_ACTOR_PLAY_EFT("I_bat003", "TOP", 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 95:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "TOP", 0);
				break;
			case 108:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG05");
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("I_bat013", "BOT", 0);
				break;
			case 113:
				//DRT_ACTOR_PLAY_EFT("I_bat013", "BOT", 0);
				break;
			case 114:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 115:
				//DRT_ACTOR_PLAY_EFT("I_bat013", "BOT", 0);
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("I_bat013", "BOT", 0);
				break;
			case 117:
				//DRT_ACTOR_PLAY_EFT("F_explosion027_blue", "BOT", 0);
				break;
			case 127:
				break;
			case 128:
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_force007_vilolet2", "MID");
				break;
			case 131:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 139:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				break;
			case 140:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				break;
			case 147:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG06");
				break;
			case 152:
				//DRT_ACTOR_PLAY_EFT("F_wizard_Mastema_shot_ground_dark", "BOT", 0);
				break;
			case 157:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 158:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 159:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				break;
			case 160:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				break;
			case 168:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 169:
				//DRT_ACTOR_PLAY_EFT("F_smoke182_spread_out_dark", "BOT", 0);
				break;
			case 174:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 175:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				break;
			case 190:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG07");
				break;
			case 195:
				await track.Dialog.Msg("CASTLE102_MQ_05_DLG08");
				break;
			case 210:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_holy_loop", "BOT");
				break;
			case 217:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_RUN_FUNCTION("SCR_CASTLE102_MQ_05_DAYLIGHT_SET");
				break;
			case 220:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 221:
				break;
			case 231:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 235:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 239:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 243:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 246:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_icon", "TOP", 0);
				break;
			case 263:
				//DRT_FUNC_ACT("SCR_CASTLE102_MQ_05_TRACK_END");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
