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

[TrackScript("LIMESTONE_52_5_MQ_8_TRACK")]
public class LIMESTONE525MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_5_MQ_8_TRACK");
		//SetMap("d_limestonecave_52_5");
		//CenterPos(1375.96,716.60,1009.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_5", 1343.897, 719.4183, 1070.961, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147371, "", "d_limestonecave_52_5", 1403.9, 716.6, 1009.297, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1375.963f, 716.6f, 1009.344f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_5", 1331.7, 719.4183, 957.635, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_5", 1403.07, 716.6, 1065.336, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154011, "", "d_limestonecave_52_5", 1352.767, 716.6, 1013.642, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154015, "", "d_limestonecave_52_5", 1405.835, 716.6, 954.0388, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_5", 1459.525, 716.6, 1010.751, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1455.653, 716.6125, 1014.105, 3.695652);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1398.63, 716.6125, 1014.481, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1405.091, 718.1775, 950.3932, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1345.475, 719.4183, 1010.435, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1397.501, 716.6125, 1069.783, 0);
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
			case 1:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_1");
				break;
			case 3:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_2");
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_explosion032_red", "BOT", 0);
				break;
			case 30:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_3");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground131_dark_red", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_drop_stone001", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_4");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light106_drop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_light104_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_LastRites_buff2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_LastRites_buff2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_LastRites_buff2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_LastRites_buff2", "BOT");
				break;
			case 51:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_5");
				break;
			case 53:
				//DRT_ACTOR_ATTACH_EFFECT("F_light070_loop_event", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light070_loop_event", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("None", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light070_loop_event", "BOT");
				break;
			case 58:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_8_TRACK_6");
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ausirine_shot_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ausirine_shot_light", "BOT");
				break;
			case 59:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow2", "BOT");
				break;
			case 61:
				character.AddSessionObject(PropertyName.LIMESTONE_52_5_MQ_8, 1);
				break;
			case 62:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
