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

[TrackScript("EP13_2_DPRISON1_MQ_7_TRACK_1")]
public class EP132DPRISON1MQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_7_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(736.80,207.00,1375.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(736.7961f, 207.0002f, 1375.657f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", -24.70764, 207, 1524.808, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59675, "", "ep13_2_d_prison_1", -95.87806, 207, 1531.086, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151094, "", "ep13_2_d_prison_1", -119.516, 207, 1513.421, 4.642857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20063, "", "ep13_2_d_prison_1", -103.1002, 207, 1524.45, 4.107143);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", -232.6125, 207, 1521.715, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59666, "", "ep13_2_d_prison_1", 243.3778, 207, 1223.732, 102);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59666, "", "ep13_2_d_prison_1", 334.8741, 207, 1336.716, 105);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59665, "", "ep13_2_d_prison_1", 282.0504, 207, 1301.116, 104.5);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59667, "", "ep13_2_d_prison_1", 294.5729, 207, 1246.283, 101);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 151089, "", "ep13_2_d_prison_1", -90.47911, 207, 1564.289, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20062, "", "ep13_2_d_prison_1", -107.2616, 207, 1548.089, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20060, "", "ep13_2_d_prison_1", -86.95158, 207, 1533.205, 1.041667);
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
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground212_spread_out_red", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_blood009_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground133_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_out029_red", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup001_dark", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup006_dark", "BOT", 0);
				break;
			case 51:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON1_MQ_7_DLG1", 10);
				break;
			case 67:
				break;
			case 77:
				//TRACK_MON_LOOKAT();
				break;
			case 79:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_7_MGAME_1");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
