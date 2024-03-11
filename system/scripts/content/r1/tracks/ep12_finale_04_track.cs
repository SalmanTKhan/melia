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

[TrackScript("EP12_FINALE_04_TRACK")]
public class EP12FINALE04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_FINALE_04_TRACK");
		//SetMap("f_dcapital_104");
		//CenterPos(808.71,4.10,137.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147383, "", "f_dcapital_104", 249.6066, 2.09552, 55.44781, 18.75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 401.9, 2.1, 129.09, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154040, "", "f_dcapital_104", 223.04, 2.1, 271.37, 0.3846154);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "f_dcapital_104", 223.04, 2.1, 271.37, 29.32432);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "", "f_dcapital_104", 304.3875, 2.09552, 198.9852, 1.37931);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(781.957f, 4.427387f, 141.9368f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 404.98, 2.1, 188.25, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 153091, "", "f_dcapital_104", 223.04, 2.1, 271.37, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_104", 401.9017, 2.09552, 129.0916, 0.8426967);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_104", 406.3694, 2.09552, 189.8443, 9.68504);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 154102, "", "f_dcapital_104", 341.9462, 2.09552, 195.5933, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 105032, "", "f_dcapital_104", 112.2801, 10.0605, 160.6673, 3.204225);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_light029_yellow2", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 28:
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_light078_holy_yellow_katadikazo", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_light078_holy_yellow_katadikazo", "BOT", 0);
				break;
			case 52:
				await track.Dialog.Msg("EP12_FINALE_04_DLG01");
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_ground043_lineup", "BOT", 0);
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_04_TRACK_DAYLIGHT_SET1");
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_spread_out010_dark", "BOT", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup022_red", "BOT", 0);
				break;
			case 85:
				await track.Dialog.Msg("EP12_FINALE_04_DLG02");
				break;
			case 90:
				await track.Dialog.Msg("EP12_FINALE_04_DLG03");
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 104:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_02_TRACK_DAYLIGHT_SET");
				break;
			case 109:
				await track.Dialog.Msg("EP12_FINALE_04_DLG04");
				break;
			case 114:
				await track.Dialog.Msg("EP12_FINALE_04_DLG05");
				break;
			case 118:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke181_white", "BOT");
				break;
			case 119:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground195_levitation_violet_loop", "BOT");
				break;
			case 120:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground139_light_orange", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "BOT");
				break;
			case 125:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke181_white", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_spark011_orange", "BOT", 0);
				break;
			case 129:
				//DRT_ACTOR_PLAY_EFT("F_spark011_orange", "BOT", 0);
				break;
			case 135:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke181_white", "BOT");
				break;
			case 138:
				//DRT_ACTOR_PLAY_EFT("F_spark011_orange", "BOT", 0);
				break;
			case 156:
				await track.Dialog.Msg("EP12_FINALE_04_DLG06");
				break;
			case 163:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 165:
				break;
			case 167:
				await track.Dialog.Msg("EP12_FINALE_04_DLG07");
				break;
			case 172:
				await track.Dialog.Msg("EP12_FINALE_04_DLG08");
				break;
			case 173:
				//DRT_ACTOR_PLAY_EFT("F_spread_in001_dark", "BOT", 0);
				break;
			case 185:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				break;
			case 186:
				//DRT_ACTOR_PLAY_EFT("F_wizard_Mastema_shot_ground_dark", "BOT", 0);
				break;
			case 187:
				break;
			case 188:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "MID", 0);
				break;
			case 192:
				//DRT_ACTOR_PLAY_EFT("F_spread_out051", "BOT", 0);
				break;
			case 199:
				await track.Dialog.Msg("EP12_FINALE_04_DLG09");
				break;
			case 203:
				//DRT_ACTOR_PLAY_EFT("F_light012_1", "BOT", 0);
				break;
			case 204:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				break;
			case 205:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				break;
			case 208:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_04_TRACK_DAYLIGHT_SET1");
				break;
			case 216:
				await track.Dialog.Msg("EP12_FINALE_04_DLG10");
				break;
			case 221:
				await track.Dialog.Msg("EP12_FINALE_04_DLG11");
				break;
			case 224:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 225:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in025_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				break;
			case 233:
				await track.Dialog.Msg("EP12_FINALE_04_DLG12");
				break;
			case 236:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 250:
				character.AddonMessage("NOTICE_Dm_!", "Glutton Kabad has appeared in your way! Defeat it!", 3);
				break;
			case 254:
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
