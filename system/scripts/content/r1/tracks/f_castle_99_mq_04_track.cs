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

[TrackScript("F_CASTLE_99_MQ_04_TRACK")]
public class FCASTLE99MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_99_MQ_04_TRACK");
		//SetMap("f_castle_99");
		//CenterPos(688.59,-131.12,1132.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(687.4335f, -131.1241f, 1133.592f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150214, "", "f_castle_99", 677.9772, -131.1241, 1162.205, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156159, "", "f_castle_99", 445.9775, -131.1242, 1190.605, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156158, "", "f_castle_99", 475.1833, -131.1242, 1210.202, 2.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_castle_99", 469.8761, -131.1242, 1189.361, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151041, "", "f_castle_99", 682.3531, -131.1241, 1246.621, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154011, "Kupole", "f_castle_99", 698.9973, -131.1241, 1281.586, 13.63636);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154014, "Kupole", "f_castle_99", 722.5025, -131.1241, 1238.515, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 663.1046, -131.1241, 1305.184, 3.333333);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 790.9378, -131.1242, 1251.01, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 811.692, -131.1242, 1114.21, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 706.1671, -131.1242, 1033.653, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 582.5818, -131.1242, 1080.607, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 155051, "UnvisibleName", "f_castle_99", 558.2271, -131.1241, 1213.277, 5);
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
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG1");
				break;
			case 7:
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "MID", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 20:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG2");
				break;
			case 22:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG3");
				break;
			case 24:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG4");
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 35:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG5");
				break;
			case 37:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG6");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion028_red", "MID", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_spread_in50_darkred", "MID", 0);
				break;
			case 58:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG7");
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 72:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG8");
				break;
			case 87:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 92:
				await track.Dialog.Msg("F_CASTLE_99_MQ_04_TRACK_DLG9");
				break;
			case 99:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
