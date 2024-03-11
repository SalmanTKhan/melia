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

[TrackScript("LIMESTONE_52_5_MQ_9_AFTER")]
public class LIMESTONE525MQ9AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_5_MQ_9_AFTER");
		//SetMap("d_limestonecave_52_5");
		//CenterPos(1372.81,716.60,1012.61);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_5", 1333.608, 726.7339, 1078.947, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147371, "", "d_limestonecave_52_5", 1405.088, 716.6, 1008.533, 12.36842);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1381.379f, 719.4f, 1003.413f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1339.484, 719.4, 1072.445, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_5", 1329.513, 719.4183, 965.3116, 1.666667);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154011, "", "d_limestonecave_52_5", 1336.945, 719.4, 1011.311, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_5", 1408.452, 719.4, 1082.996, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154015, "", "d_limestonecave_52_5", 1404.513, 719.4, 940.7769, 0.5333334);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_5", 1481.045, 719.4, 1012.135, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1324.137, 719.4, 1088.396, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1359.262, 719.4059, 1011.412, 30);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1374.374, 717.4521, 1039.898, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1333.587, 724.1274, 1076.103, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1349.075, 719.4183, 1032.001, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1381.316, 716.8811, 1064.903, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1311.154, 719.4182, 1009.318, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1406.332, 719.4183, 938.6913, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1484.395, 716.6125, 1012.677, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1403.475, 716.6125, 1087.585, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1327.078, 719.4183, 1015.955, 0);
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
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion026_rize_red2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_line004_red", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke2", "BOT");
				break;
			case 14:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_1");
				break;
			case 18:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_2");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground131_loop", "BOT");
				break;
			case 24:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_3");
				break;
			case 26:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_4");
				break;
			case 28:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_5");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_samsara_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_samsara_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_samsara_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_samsara_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_light029_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light029_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light029_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light029_yellow", "BOT");
				break;
			case 38:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_6");
				break;
			case 41:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_7");
				break;
			case 43:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_8");
				break;
			case 45:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_9");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_dash012_yellow_loop", "BOT");
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow2", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 58:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_AFTER_10");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("E_wizard_BloodSucking_bloodline", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_wizard_BloodSucking_bloodline", "BOT");
				break;
			case 73:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion87", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light048_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light029_yellow", "BOT");
				break;
			case 74:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic029_red_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_force080_violet", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion079_blood2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_event", "BOT");
				break;
			case 75:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_godsmash_shot_explosion", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup014_yellow", "BOT");
				break;
			case 76:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_SummonServant_buff2", "BOT");
				break;
			case 84:
				character.AddSessionObject(PropertyName.LIMESTONE_52_5_MQ_9, 1);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
