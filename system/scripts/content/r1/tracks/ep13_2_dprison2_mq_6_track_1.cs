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

[TrackScript("EP13_2_DPRISON2_MQ_6_TRACK_1")]
public class EP132DPRISON2MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON2_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_2");
		//CenterPos(-1029.36,546.48,-74.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1030.042f, 546.4807f, -75.22213f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157112, "", "ep13_2_d_prison_2", -1062.395, 546.4807, -72.78847, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_2", -1065.107, 546.4807, -42.2294, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47273, "", "ep13_2_d_prison_2", -1187.455, 546.4807, -66.85577, 25.76923);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59661, "", "ep13_2_d_prison_2", -1138.884, 551.2819, 39.60427, 322.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59661, "", "ep13_2_d_prison_2", -1124.721, 551.2819, -173.2771, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59659, "", "ep13_2_d_prison_2", -1132.022, 546.4807, -25.0516, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59659, "", "ep13_2_d_prison_2", -1175.581, 546.4807, -90.2467, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_SETPOS();
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "BOT", 0);
				break;
			case 32:
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("I_only_quest_smoke058_blue", "BOT", 0);
				break;
			case 49:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG1");
				break;
			case 50:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION1_MQ6_TRACK_HEADICON_1");
				break;
			case 60:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG2");
				break;
			case 61:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG3");
				break;
			case 62:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG4");
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup015_blue", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "None", "arrow_blow", "SLOW", 20, 0, 0, 0, 0, 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_light076_spread_in_blue", "BOT", 0);
				break;
			case 78:
				break;
			case 80:
				break;
			case 81:
				break;
			case 83:
				break;
			case 86:
				await track.Dialog.Msg("EP13_2_DPRISON2_MQ_6_TRACK_DLG5");
				break;
			case 89:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP13_2_DPRISON2_MQ_6_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
