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

[TrackScript("EP13_2_DPRISON3_MQ_8_TRACK_1")]
public class EP132DPRISON3MQ8TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_8_TRACK_1");
		//SetMap("None");
		//CenterPos(-170.58,15.22,72.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-152.8661f, 10f, 57.54022f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154120, "", "None", -162.3855, 13.66627, 98.69486, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47274, "", "None", -49.80248, 10, -98.82788, 8.409091);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59658, "", "None", 70.9672, 10, -236.8929, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47273, "", "None", -132.027, 10, -17.04704, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "", "None", -148.4402, 10, -258.1902, 38.33333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147469, "", "None", -143.686, 10, -170.952, 185);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "", "None", -241.261, 10, -170.9752, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "", "None", -200.2215, 10, -127.4317, 4.25);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 157113, "", "None", -144.0216, 10, -260.1511, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 157113, "", "None", -142.5973, 10, -175.3348, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 157113, "", "None", -235.4627, 10, -174.3402, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 157113, "", "None", -199.7753, 10, -127.5684, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59657, "", "None", -50.05893, 10, -100.245, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_burstup015_blue", "BOT", 0);
				break;
			case 10:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG1");
				break;
			case 11:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG2");
				break;
			case 25:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG3");
				break;
			case 26:
				//DRT_RUN_FUNCTION("SCR_EP13_2_DPRISION3_MQ8_TRACK_HEADICON_1");
				break;
			case 33:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG4");
				break;
			case 34:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_8_TRACK_DLG5");
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow009_yellow", "arrow_cast", "F_only_quest_light115_explosion_blue", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 38:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 270, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 400, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 350, 1, 200, 0, 0, 0);
				break;
			case 41:
				break;
			case 42:
				break;
			case 43:
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground083_smoke_dark", "BOT", 0);
				break;
			case 56:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_force018_trail_fire_blue_short", "arrow_cast", "I_only_quest_explosion006_ice", "arrow_blow", "FAST", 200, 1, 200, 0, 0, 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spread_in005_dark", "BOT", 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_ground093_dark", "BOT", 0);
				break;
			case 125:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON3_MQ_8_TRACK_DLG6", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
