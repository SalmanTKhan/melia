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

[TrackScript("F_3CMLAKE_86_MQ_17_TRACK")]
public class F3CMLAKE86MQ17TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_17_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(-108.53,39.66,1175.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156128, "", "f_3cmlake_86", -503.2549, 39.76004, 1150.235, 193.5714);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156126, "", "f_3cmlake_86", -153.8516, 39.31152, 1228.046, 65);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156134, "디에고", "f_3cmlake_86", -212.138, 40.31889, 1153.189, 11.42857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156123, "", "f_3cmlake_86", -134.1841, 39.81597, 1168.857, 25.71429);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156124, "", "f_3cmlake_86", -114.3786, 39.31152, 1213.825, 146.6667);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156127, "", "f_3cmlake_86", -91.05086, 39.86013, 1165.585, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 106021, "", "f_3cmlake_86", 155.989, 39.31152, 1381.951, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 156120, "", "f_3cmlake_86", -219.9236, 39.76962, 1230.957, 59.6875);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 156119, "", "f_3cmlake_86", -228.5756, 39.98055, 1280.275, 49.5);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 155026, "", "f_3cmlake_86", 153.5509, 39.31152, 1383.939, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 155026, "", "f_3cmlake_86", 153.3728, 39.31152, 1581.25, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 155026, "", "f_3cmlake_86", 153.9842, 39.31152, 1243.013, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 155.5913, 39.31152, 1381.475, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		character.Movement.MoveTo(new Position(-254.029f, 40.89014f, -232.1479f));
		actors.Add(character);

		var mob13 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", -89.14386, 39.97568, 1117.476, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", -54.90046, 39.75252, 1160.37, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", -97.34898, 39.31152, 1359.575, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", -70.00715, 39.31152, 1400.769, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 53.29424, 39.31152, 1617.448, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 29.81677, 39.31152, 1658.222, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 193.5973, 39.31152, 1212.447, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 218.5096, 39.31152, 1255.421, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 371.3474, 39.31152, 1515.065, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 156107, "UnvisibleName", "f_3cmlake_86", 347.1281, 39.31152, 1554.243, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 152.5511, 40.7121, 1384.017, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				break;
			case 13:
				break;
			case 64:
				break;
			case 113:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb003_dark", "BOT");
				break;
			case 114:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb003_dark", "BOT");
				break;
			case 115:
				//DRT_ACTOR_PLAY_EFT("F_ground012_light", "BOT", 0);
				break;
			case 116:
				//DRT_ACTOR_ATTACH_EFFECT("I_exclamation_dark", "MID");
				//DRT_ACTOR_PLAY_EFT("F_lineup010_ground", "BOT", 0);
				break;
			case 117:
				//DRT_ACTOR_ATTACH_EFFECT("I_exclamation_dark", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_exclamation_dark", "MID");
				break;
			case 118:
				//DRT_ACTOR_ATTACH_EFFECT("I_exclamation_dark", "MID");
				break;
			case 153:
				break;
			case 171:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_17_DLG1");
				break;
			case 185:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
