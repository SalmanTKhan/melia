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

[TrackScript("F_MAPLE_24_2_MQ_11_TRACK")]
public class FMAPLE242MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_11_TRACK");
		//SetMap("f_maple_24_2");
		//CenterPos(-1361.72,11.09,-548.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_2", -1371.001, 11.09299, -523.0507, 640);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1240.308f, 11.09299f, -528.7079f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 156159, "Kartas", "f_maple_24_2", -1037.55, 11.09299, -492.8908, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "f_maple_24_2", -1193.037, 11.09299, -515.9296, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57578, "", "f_maple_24_2", -1186.113, 11.09299, -501.8539, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57579, "", "f_maple_24_2", -1172.658, 15.80709, -541.1627, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57223, "", "f_maple_24_2", -1196.224, 11.09299, -517.7552, 33.33333, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147448, "", "f_maple_24_2", -1251.21, 11.09299, -569.8859, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1239.779, 11.09299, -638.7585, 0.07246377);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57580, "", "f_maple_24_2", -1196.739, 11.09299, -646.1333, 21.875);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1239.665, 11.09299, -609.4639, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1335.455, 11.09299, -543.3721, 1.369863);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 154102, "", "f_maple_24_2", -1247.16, 11.09299, -602.7241, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_01");
				break;
			case 9:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_02");
				break;
			case 25:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_03");
				break;
			case 26:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_04");
				break;
			case 31:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_05");
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_explosion102_red_event", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 44:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_06");
				break;
			case 47:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_07");
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("I_light010_2_loop2", "MID");
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 59:
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_spin026", "BOT", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_spin015", "BOT", 0);
				break;
			case 64:
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot", "BOT");
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 69:
				//DRT_SETPOS();
				//DRT_SETPOS();
				//DRT_SETPOS();
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_spin026", "BOT", 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spin015", "BOT", 0);
				break;
			case 80:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 83:
				//DRT_SETPOS();
				//DRT_SETPOS();
				//DRT_SETPOS();
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("F_wizard_stop_shot", "BOT", 0);
				break;
			case 92:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_DLG_01");
				break;
			case 93:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_08");
				break;
			case 98:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_09");
				break;
			case 100:
				//DRT_ACTOR_PLAY_EFT("F_spread_in024_red", "BOT", 0);
				break;
			case 108:
				//DRT_ACTOR_PLAY_EFT("F_ground167", "BOT", 0);
				break;
			case 109:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_zemina_mash_loop_blue_1", "BOT");
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("F_explosion102_red_event", "BOT", 0);
				break;
			case 118:
				//DRT_SETPOS();
				break;
			case 120:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_10");
				break;
			case 122:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 125:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 128:
				await track.Dialog.Msg("F_MAPLE_242_TRACK3_11");
				break;
			case 130:
				//DRT_ACTOR_PLAY_EFT("F_spin026", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground020", "BOT", 0);
				break;
			case 131:
				//DRT_ACTOR_PLAY_EFT("F_spin015", "BOT", 0);
				break;
			case 133:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				break;
			case 134:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 135:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
