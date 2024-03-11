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

[TrackScript("STARTOWER_92_MQ_50_TRACK")]
public class STARTOWER92MQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_92_MQ_50_TRACK");
		//SetMap("d_startower_92");
		//CenterPos(-973.85,607.32,1502.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-973.849f, 607.3212f, 1502.206f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150182, "", "d_startower_92", -1374.37, 670.7653, 1441.059, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 105023, "Schaffenstar", "d_startower_92", -1337.44, 670.77, 1419.02, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154066, "", "d_startower_92", -1189.892, 677.541, 1483.839, 2.222222);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47236, "", "d_startower_92", -1168.83, 677.54, 1478.13, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154066, "", "d_startower_92", -1188.442, 670.7653, 1469.636, 97.91666);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 152076, "", "d_startower_92", -924.9291, 513.0074, 1371.965, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_startower_92", -1426.024, 735.3651, 1407.079, 4);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 152057, "UnvisibleName", "d_startower_92", -1377.96, 670.7653, 1443.562, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_startower_92", -1423.989, 736.078, 1418.828, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_startower_92", -1428.907, 736.078, 1415.08, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("STARTOWER_92_MQ_50_TRACK_DLG1");
				break;
			case 23:
				await track.Dialog.Msg("STARTOWER_92_MQ_50_TRACK_DLG2");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_suppress_loop_debuff", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light135", "BOT");
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("I_cylinder010_light_dark", "BOT", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_Gregorate_shot_light", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_pc_shield_square", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_arrow020_ignas_mon_mesh2", "TOP");
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_item_drop_line_loop_white", "BOT", 0);
				break;
			case 99:
				//DRT_ACTOR_ATTACH_EFFECT("F_light019", "BOT");
				break;
			case 101:
				//DRT_ACTOR_ATTACH_EFFECT("F_light019", "BOT");
				break;
			case 103:
				//DRT_ACTOR_ATTACH_EFFECT("F_light019", "BOT");
				break;
			case 111:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground139_light_orange", "BOT");
				break;
			case 119:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_50_TRACK_ATTACH");
				break;
			case 127:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_UmbilicalCord_shot_lineup", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 128:
				//DRT_ACTOR_PLAY_EFT("F_cleric_Revival_light", "BOT", 0);
				break;
			case 129:
				//DRT_RUN_FUNCTION("SCR_STARTOWER_92_MQ_50_TRACK_DETACH");
				break;
			case 174:
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
