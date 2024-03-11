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

[TrackScript("EP13_2_DPRISON1_MQ_10_TRACK_1")]
public class EP132DPRISON1MQ10TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_10_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(-1214.36,408.70,1426.20);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1215.73f, 408.7056f, 1427.431f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", -1396.977, 408.8012, 1421.589, 15.54348);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_2_d_prison_1", -1296.337, 408.7481, 1417.979, 252.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_1", -1353.794, 408.8654, 2196.096, 98.22581);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150238, "", "ep13_2_d_prison_1", -1454.716, 408.8654, 1675.126, 30.71429);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_warrior_skyline_shot_Highlander01_3", "MID", 0);
				break;
			case 22:
				//DRT_RUN_FUNCTION("SCR_MQ10_TRACK_ADDBUFF");
				//DRT_ACTOR_ATTACH_EFFECT("F_only_quest_rize022_ground_dark_loop", "BOT");
				break;
			case 33:
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke186_dark", "BOT", 0);
				break;
			case 70:
				//DRT_CLEAR_EFFECT();
				break;
			case 74:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG1");
				break;
			case 77:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG9");
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion123_dark", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force107_dark", "mon_dark_spirit_blow", "F_only_quest_smoke068_dark", "None", "FAST", 200, 0, 0, 0, 0, 0);
				break;
			case 82:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow005_mash2", "arrow_cast", "F_only_quest_explosion078_dark", "arrow_blow", "FAST", 300, 0, 0, 1, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_levitation015_dark", "BOT", 0);
				break;
			case 102:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG2");
				break;
			case 103:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG3");
				break;
			case 104:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG4");
				break;
			case 105:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG5");
				break;
			case 117:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG6");
				break;
			case 118:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG7");
				break;
			case 119:
				await track.Dialog.Msg("EP13_2_DPRISON1_MQ_10_DLG8");
				break;
			case 128:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup006_dark", "BOT", 0);
				break;
			case 132:
				//DRT_CLEAR_EFFECT();
				break;
			case 151:
				//DRT_RUN_FUNCTION("SCR_MQ10_TRACK_ADDBUFF");
				break;
			case 153:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
