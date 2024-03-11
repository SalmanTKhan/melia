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

[TrackScript("PILGRIM41_5_SQ07_TRACK")]
public class PILGRIM415SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_5_SQ07_TRACK");
		//SetMap("f_pilgrimroad_41_5");
		//CenterPos(1369.01,37.84,-1092.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1369.008f, 37.83511f, -1092.699f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47107, "", "f_pilgrimroad_41_5", 1404.579, 37.8351, -1129.386, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_5", 1030.735, 37.81583, -770.4991, 33);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156006, "", "f_pilgrimroad_41_5", 1120.4, 37.84, -867.7, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57957, "", "f_pilgrimroad_41_5", 939.4548, 16.31296, -692.3034, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57957, "", "f_pilgrimroad_41_5", 926.1422, 4.0605, -639.3275, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57957, "", "f_pilgrimroad_41_5", 967.4337, 15.45187, -679.536, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57961, "", "f_pilgrimroad_41_5", 918.1496, 8.310845, -662.2103, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57961, "", "f_pilgrimroad_41_5", 899.3984, 4.060513, -623.8148, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_5", 956.4961, 24.54326, -721.594, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_5", 1011.408, 26.26587, -713.6282, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_5", 974.6606, 24.17411, -717.4532, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_5", 988.238, 22.73275, -706.3669, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20046, "", "f_pilgrimroad_41_5", 1170.19, 37.84, -861.11, 35);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke143_dark_red_loop", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation020_dark2", "MID");
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 1);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 37:
				await track.Dialog.Msg("PILGRIM415_SQ_07_track1");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_light080_blue", "MID", 1);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 48:
				await track.Dialog.Msg("PILGRIM415_SQ_07_track2");
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 1);
				break;
			case 74:
				break;
			case 77:
				await track.Dialog.Msg("PILGRIM415_SQ_07_track3");
				break;
			case 86:
				break;
			case 87:
				//CREATE_BATTLE_BOX_INLAYER(0);
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_SETTENDENCY();
				break;
			case 90:
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop2", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
