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

[TrackScript("EP13_F_SIAULIAI_3_MQ_04_TRACK")]
public class EP13FSIAULIAI3MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_MQ_04_TRACK");
		//SetMap("ep13_f_siauliai_3");
		//CenterPos(823.50,271.21,-251.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(819.8024f, 274.8981f, -254.0114f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_f_siauliai_3", 859.4213, 280.5747, -575.9606, 5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150242, "", "ep13_f_siauliai_3", 866.724, 280.5747, -573.1004, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150206, "", "ep13_f_siauliai_3", 833.2845, 280.5747, -607.1341, 95.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150206, "", "ep13_f_siauliai_3", 809.4551, 280.5747, -406.7239, 23.33333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150242, "", "ep13_f_siauliai_3", 870.929, 280.5747, -412.6222, 0);
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
			case 40:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 41:
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 59:
				//DRT_RUN_FUNCTION("SCR_EP13_F_SIAULIAI_3_MQ_07_TRACK_DAYLIGHT_SET1");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_spread_in032_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_hit009_rize_red", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_explosion128_white", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_levitation033_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "BOT");
				break;
			case 78:
				//DRT_RUN_FUNCTION("SCR_EP13_F_SIAULIAI_3_MQ_07_TRACK_DAYLIGHT_CLEAR");
				break;
			case 95:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T1");
				break;
			case 96:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T2");
				break;
			case 97:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T3");
				break;
			case 100:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				break;
			case 102:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "BOT");
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 104:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 107:
				//DRT_ACTOR_PLAY_EFT("F_light018_yellow", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				break;
			case 108:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T4");
				break;
			case 109:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T5");
				break;
			case 110:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG_T6");
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "MID", 0);
				break;
			case 125:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_3_MQ_04_DLG_T7", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
