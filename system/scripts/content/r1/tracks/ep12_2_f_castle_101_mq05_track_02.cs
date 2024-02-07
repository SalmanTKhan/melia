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

[TrackScript("EP12_2_F_CASTLE_101_MQ05_TRACK_02")]
public class EP122FCASTLE101MQ05TRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ05_TRACK_02");
		//SetMap("f_castle_101");
		//CenterPos(-1068.36,52.93,-873.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1122.341f, 52.92822f, -795.7823f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", -1213.929, 52.92822, -751.3659, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "f_castle_101", -1099.638, 52.92822, -812.2518, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150230, "", "f_castle_101", -1126.4, 52.92822, -811.2578, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", 943.3959, 124.5477, 418.522, 0.09803922);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", 579.9424, 52.92822, 67.26445, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150233, "", "f_castle_101", 589.487, 52.92822, -21.68367, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150233, "", "f_castle_101", 676.9041, 52.92822, 57.87614, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150234, "", "f_castle_101", 653.0115, 52.92822, -2.4352, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", 1011.13, 52.92822, -687.3433, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150231, "", "f_castle_101", 986.4597, 52.92822, -589.5549, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150231, "", "f_castle_101", 910.3251, 52.92822, -680.6591, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150231, "", "f_castle_101", 1076.096, 52.92822, -626.2664, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", 316.0294, 52.92822, -1030.951, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", -911.7116, 52.92822, 70.97333, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", -929.5829, 124.5477, 469.7161, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", -1543.717, 52.92822, -414.3185, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_2");
				break;
			case 11:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_3");
				break;
			case 14:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ05_DLG_7", 2);
				break;
			case 27:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_4");
				break;
			case 42:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				break;
			case 56:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_5");
				break;
			case 69:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_04");
				break;
			case 82:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_04");
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 106:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 110:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 122:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 126:
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 130:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 135:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 139:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
