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

[TrackScript("EP13_2_DPRISON1_MQ_6_TRACK_1")]
public class EP132DPRISON1MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(996.09,230.78,1114.26);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(996.0857f, 230.7766f, 1114.264f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", 771.2236, 207.0003, 1362.712, 39.75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154040, "", "ep13_2_d_prison_1", 661.6937, 207, 1369.176, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59665, "", "ep13_2_d_prison_1", 930.4445, 214.951, 1154.34, 91);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59665, "", "ep13_2_d_prison_1", 907.8555, 211.1399, 1578.216, 99.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59667, "", "ep13_2_d_prison_1", 901.2894, 211.1399, 1580.242, 97.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59667, "", "ep13_2_d_prison_1", 930.9888, 215.028, 1152.889, 101.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 42:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_6_DLG1");
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke191_blue", "BOT", 0);
				break;
			case 45:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_6_DLG2");
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "MID", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke185_spread_out_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground083_smoke_dark", "BOT", 0);
				break;
			case 66:
				break;
			case 76:
				//TRACK_MON_LOOKAT();
				break;
			case 79:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_6_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
