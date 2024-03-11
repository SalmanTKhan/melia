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

[TrackScript("M_FLIBRAY_BOSS_BEFORE")]
public class MFLIBRAYBOSSBEFORE : TrackScript
{
	protected override void Load()
	{
		SetId("M_FLIBRAY_BOSS_BEFORE");
		//SetMap("mission_fantasylibrary_1");
		//CenterPos(1454.88,-8.96,743.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154080, "", "mission_fantasylibrary_1", 1300.151, -8.964798, 1033.533, 1.206897);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154086, "", "mission_fantasylibrary_1", 1322.261, -8.964798, 1102.458, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1495.368f, -8.964798f, 904.0417f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 154087, "", "mission_fantasylibrary_1", 1417.22, -8.964798, 974.9842, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57827, "", "mission_fantasylibrary_1", 1406.608, -8.964798, 885.8554, 25, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57581, "", "mission_fantasylibrary_1", 1390.678, -8.964798, 1035.68, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "mission_fantasylibrary_1", 1446.947, -8.964798, 945.6791, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147466, "UnvisibleName", "mission_fantasylibrary_1", 1450.529, -8.964798, 945.7106, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var npc0 = Shortcuts.AddNpc(0, 59033, "", "mission_fantasylibrary_1", 1367.167, -8.964798, 990.1294, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "mission_fantasylibrary_1", 1367.17, -8.96, 990.13, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20024, "", "mission_fantasylibrary_1", 1462.66, -8.86, 977.68, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20024, "", "mission_fantasylibrary_1", 1417.22, -8.96, 974.98, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20024, "", "mission_fantasylibrary_1", 1400.77, -8.96, 891.91, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20024, "", "mission_fantasylibrary_1", 1450.53, -8.96, 945.71, 0);
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
			case 6:
				await track.Dialog.Msg("M_FLIB_DIR_B_1");
				break;
			case 7:
				await track.Dialog.Msg("M_FLIB_DIR_B_2");
				break;
			case 8:
				await track.Dialog.Msg("M_FLIB_DIR_B_3");
				break;
			case 9:
				await track.Dialog.Msg("M_FLIB_DIR_B_4");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_light003_blue", "MID");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup010_ground", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground_white", "BOT");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup015_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup015_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				break;
			case 46:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out032_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup015_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup015_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow", "BOT");
				break;
			case 56:
				//SCR_SAME_LAYER_SETPOS_FADEOUT_RUN(-30, 30);
				break;
			case 57:
				await track.Dialog.Msg("M_FLIB_DIR_B_5");
				break;
			case 58:
				await track.Dialog.Msg("M_FLIB_DIR_B_6");
				break;
			case 59:
				await track.Dialog.Msg("M_FLIB_DIR_B_7");
				break;
			case 60:
				await track.Dialog.Msg("M_FLIB_DIR_B_8");
				break;
			case 64:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				break;
			case 65:
				await track.Dialog.Msg("M_FLIB_DIR_B_9");
				break;
			case 70:
				await track.Dialog.Msg("M_FLIB_DIR_B_10");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_FrostCloud_loop", "BOT");
				break;
			case 71:
				await track.Dialog.Msg("M_FLIB_DIR_B_11");
				break;
			case 74:
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern007_explosion_mash_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup002_blue", "BOT");
				break;
			case 75:
				await track.Dialog.Msg("M_FLIB_DIR_B_12");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out037_violet_ice_leaf", "BOT");
				break;
			case 77:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_cast", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground143_violet_ice", "BOT");
				break;
			case 78:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_cast", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				break;
			case 79:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_shot", "BOT");
				break;
			case 84:
				//DRT_RUN_FUNCTION("SCR_STAGE9_PREVIOUS_DIRECTION_END");
				break;
			case 85:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Froster Lord!", 8);
				//DRT_FACTIONCHANGE("Monster");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
