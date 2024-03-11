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

[TrackScript("EP13_2_DPRISON3_MQ_7_TRACK_1")]
public class EP132DPRISON3MQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_7_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(-229.20,20.87,82.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-228.1468f, 20.8731f, 80.63823f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59658, "Paulius", "ep13_2_d_prison_3", 215.4977, 16.50926, -448.3076, 0, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_3", -40.83959, 10, -23.52389, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47281, "", "ep13_2_d_prison_3", 223.4588, 16.02371, -548.3258, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47273, "", "ep13_2_d_prison_3", -74.28489, 10, -77.73215, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47274, "", "ep13_2_d_prison_3", -50.88891, 10, -96.58554, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON3_MQ_7_TRACK_DLG1", 2);
				break;
			case 28:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG2");
				break;
			case 29:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG3");
				break;
			case 32:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG4");
				break;
			case 35:
				break;
			case 37:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG5");
				break;
			case 38:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG6");
				break;
			case 39:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG7");
				break;
			case 40:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG8");
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG9");
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup015_blue", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in030_ice1_blue", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion098_dark_blue", "BOT", 0);
				//DRT_RUN_FUNCTION("SCR_DPRISON3_MQ7_ADDBUFF");
				//DRT_FACTIONCHANGE("Monster");
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "MID", 0);
				//DRT_RUN_FUNCTION("SCR_DPRISON3_MQ7_ADDBUFF_STUN");
				break;
			case 79:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ1_TRACK_HEADICON_1");
				break;
			case 83:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_7_TRACK_DLG10");
				break;
			case 89:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
