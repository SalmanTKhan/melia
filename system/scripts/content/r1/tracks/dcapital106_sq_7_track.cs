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

[TrackScript("DCAPITAL106_SQ_7_TRACK")]
public class DCAPITAL106SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL106_SQ_7_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(402.88,260.57,1120.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(402.8816f, 260.5712f, 1120.291f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57579, "", "f_dcapital_106", 104.4932, 286.3376, 1415.412, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154016, "", "f_dcapital_106", 61.64581, 286.4155, 1408.233, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 332.7671, 286.0322, 1556.579, 40.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", 277.1407, 286.1021, 1433.041, 31.66667);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 301.405, 286.0602, 1479.074, 83.75);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", 359.094, 285.9378, 1506.288, 38.57143);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", 256.1156, 286.1559, 1522.807, 48.75);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", 341.5739, 285.9636, 1408.69, 6.666667);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 385.42, 285.8636, 1444.191, 12.77778);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57578, "", "f_dcapital_106", 395.1663, 260.833, 1096.526, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "f_dcapital_106", 352.747, 285.9448, 1479.672, 0);
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
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_green", "BOT", 0);
				break;
			case 25:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG1");
				break;
			case 31:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG2");
				break;
			case 36:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG3");
				break;
			case 40:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG4");
				break;
			case 45:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG5");
				break;
			case 50:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG6");
				break;
			case 78:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG7");
				break;
			case 86:
				break;
			case 87:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 120, 1, 0, 5, 10, 0);
				break;
			case 96:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				break;
			case 106:
				await track.Dialog.Msg("DCAPITAL106_SUBQ92_DLG8");
				break;
			case 107:
				break;
			case 114:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
