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

[TrackScript("EP12_2_F_CASTLE_101_MQ04_2_TRACK_01")]
public class EP122FCASTLE101MQ042TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ04_2_TRACK_01");
		//SetMap("None");
		//CenterPos(-1494.80,52.93,-350.71);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1440.625f, 52.92823f, -384.9875f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150232, "", "None", -1541.696, 52.92822, -415.6457, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150230, "", "None", -1465.403, 52.92824, -384.0672, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "None", -1506.848, 52.92822, -335.6888, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59523, "", "None", -1578.468, 52.92822, -354.8346, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59524, "", "None", -1513.963, 52.92823, -359.7733, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59525, "", "None", -1476.819, 52.92824, -392.4684, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59526, "", "None", -1482.288, 52.92822, -432.9027, 0);
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
			case 5:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_5");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_red4", "MID");
				//DRT_ACTOR_PLAY_EFT("I_buff_003_red2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic004_red", "BOT", 0);
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force081_red2", "skl_eff_twistoffate_force", "F_blood009_red", "skl_eff_force_hit", "SLOW", 25, 1, 0, 0, 10, 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion099_red", "MID", 0);
				break;
			case 54:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				break;
			case 68:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_6");
				break;
			case 69:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ04_2_DLG_7");
				break;
			case 78:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
