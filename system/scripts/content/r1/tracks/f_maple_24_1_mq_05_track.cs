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

[TrackScript("F_MAPLE_24_1_MQ_05_TRACK")]
public class FMAPLE241MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_1_MQ_05_TRACK");
		//SetMap("f_maple_24_1");
		//CenterPos(-585.81,1.49,-844.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_1", 404.1263, 35.5449, -115.9179, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(546.3016f, 35.5449f, -80.18437f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 156159, "", "f_maple_24_1", -967.8458, 1.4935, -919.5576, 1.309524);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59255, "", "f_maple_24_1", -839.7998, 1.4935, -846.0197, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59255, "", "f_maple_24_1", -833.9981, 1.4935, -943.3627, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59255, "", "f_maple_24_1", -869.5007, 1.4935, -875.4114, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59255, "", "f_maple_24_1", -868.223, 1.4935, -913.183, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57578, "", "f_maple_24_1", 425.5171, 35.5449, -62.57014, 7.7);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", -840.5878, 1.4935, -849.8757, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", -866.6812, 1.4935, -917.8272, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", -869.9266, 1.4935, -878.1656, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", -835.7518, 1.4935, -943.9495, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", 612.5778, 35.5449, -278.9456, 2.864078);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 156159, "Kartas", "f_maple_24_1", 573.6172, 35.5449, -19.85453, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", 419.8409, 35.5449, -116.9112, 565);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", 405.2489, 35.5449, -117.0791, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", 518.9167, 35.5449, -31.14796, 110);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 154011, "", "f_maple_24_1", 591.7005, 35.5449, -257.6977, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation006_loop", "MID");
				break;
			case 41:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_01");
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 53:
				break;
			case 54:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_02");
				break;
			case 73:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_03");
				break;
			case 81:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_04");
				break;
			case 85:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 87:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 89:
				break;
			case 90:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere006_mash", "BOT");
				break;
			case 91:
				//DRT_FUNC_ACT("SCR_F_MAPLE_241_MQ_05_TRACK_FUNC1");
				break;
			case 96:
				//DRT_SETPOS();
				//DRT_SETPOS();
				//DRT_SETPOS();
				//DRT_SETPOS();
				break;
			case 101:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_05");
				break;
			case 105:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_06");
				break;
			case 110:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_07");
				break;
			case 114:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_08");
				break;
			case 117:
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red2", "TOP", 0);
				break;
			case 119:
				//DRT_ACTOR_ATTACH_EFFECT("I_force079_yellow", "TOP");
				break;
			case 129:
				await track.Dialog.Msg("F_MAPLE_241_TRACK_09");
				break;
			case 132:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 133:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red_1", "BOT", 0);
				break;
			case 134:
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red_1", "BOT", 0);
				break;
			case 138:
				//DRT_ACTOR_PLAY_EFT("F_spread_out029_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out029_red", "BOT", 0);
				break;
			case 139:
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				break;
			case 154:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 159:
				//DRT_PLAY_MGAME("F_MAPLE_24_1_MQ_05_MINI");
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "The Kupole's scream has drawn the attention of demons!{nl}Protect the Kupole from the demons!", 7);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
