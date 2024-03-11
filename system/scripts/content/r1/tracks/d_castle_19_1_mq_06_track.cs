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

[TrackScript("D_CASTLE_19_1_MQ_06_TRACK")]
public class DCASTLE191MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("D_CASTLE_19_1_MQ_06_TRACK");
		//SetMap("d_castle_19_1");
		//CenterPos(-169.74,-8.95,-32.53);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147382, "", "d_castle_19_1", 4.789169, 2.712414, -82.50429, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151041, "", "d_castle_19_1", -209.052, -8.953865, -31.26914, 1.612903);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150206, "", "d_castle_19_1", -81.69945, 2.739555, 41.03949, 21.42857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 495.2897, 61.82259, 70.38406, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 18.70233, 19.42841, -496.2624, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 102.2804, 19.42841, -508.2714, 580);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", -310.368, 142.2863, 823.7414, 2017.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-170.4916f, -8.953862f, -30.24953f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", -4.643059, 2.7167, -76.60167, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 48.06181, 2.689376, 23.41953, 9.117647);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147382, "", "d_castle_19_1", 50.29494, 2.688616, 19.3232, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 11.02496, 2.710197, -106.9816, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150210, "", "d_castle_19_1", -0.06151581, 2.705974, 41.90541, 21.66667);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_castle_19_1", 5.222485, 2.703609, 41.85763, 0);
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
			case 1:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG1");
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 10:
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_light059", "MID", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("I_bomb003_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light059", "MID", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("I_bomb003_dark", "MID", 0);
				break;
			case 18:
				break;
			case 25:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG2");
				break;
			case 26:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG3");
				break;
			case 28:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG4");
				break;
			case 32:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke001_black_loop", "mute", "None", "mute", "SLOW", 300, 0.5, 250, 0, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force033_dark", "mute", "None", "mute", "SLOW", 300, 0.5, 250, 0, 10, 0);
				break;
			case 39:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke001_black_loop", "mute", "I_explosion002_green", "mute", "SLOW", 450, 0.5, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force033_dark", "mute", "I_explosion002_green", "mute", "SLOW", 450, 0.5, 0, 5, 10, 0);
				break;
			case 67:
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 80:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 82:
				break;
			case 86:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG5");
				break;
			case 87:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG6");
				break;
			case 88:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG7");
				break;
			case 89:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG8");
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_smoke120_dark", "BOT", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 95:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "BOT", 0);
				break;
			case 97:
				//DRT_ACTOR_PLAY_EFT("I_smoke023_dark", "BOT", 0);
				break;
			case 101:
				await track.Dialog.Msg("D_CASTLE_19_1_MQ_16_TRACK_DLG9");
				break;
			case 109:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
