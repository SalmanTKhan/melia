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

[TrackScript("PILGRIM41_2_SQ07_TRACK")]
public class PILGRIM412SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_2_SQ07_TRACK");
		//SetMap("f_pilgrimroad_41_2");
		//CenterPos(499.51,224.25,524.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(499.5131f, 224.2539f, 524.7863f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155044, "", "f_pilgrimroad_41_2", 496.8703, 224.2539, 488.1213, 76.11111);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155043, "", "f_pilgrimroad_41_2", 859.7943, 224.2539, 531.7257, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153019, "", "f_pilgrimroad_41_2", 895.13, 224.25, 536.96, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155130, "", "f_pilgrimroad_41_2", 859.0222, 224.2539, 529.4229, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58466, "", "f_pilgrimroad_41_2", 859.79, 224.25, 531.73, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 823.6915, 224.2539, 431.8992, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 849.2813, 224.2539, 481.4761, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 832.1746, 224.2539, 580.0313, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 790.067, 224.2539, 617.0599, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 958.8226, 224.2539, 471.9862, 16.4);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 945.903, 224.2539, 594.8166, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57990, "", "f_pilgrimroad_41_2", 977.9199, 224.2539, 533.0817, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20026, "", "f_pilgrimroad_41_2", 797.6572, 224.2539, 520.6653, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20026, "", "f_pilgrimroad_41_2", 859.79, 224.25, 531.73, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 155044, "", "f_pilgrimroad_41_2", 543.93, 224.25, 664.58, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force033_dark2", "", "I_smoke012_dark2", "", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke001_dark_3", "", "F_None_loop", "", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force033_dark2", "", "I_smoke012_dark2", "", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke001_dark_3", "", "F_None_loop", "", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force033_dark2", "", "I_smoke012_dark2", "", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke001_dark_3", "", "F_None_loop", "", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation028_smoke", "BOT");
				break;
			case 44:
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize011", "TOP");
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize011", "TOP");
				break;
			case 59:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize011", "TOP");
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize011", "TOP");
				break;
			case 62:
				//DisableBornAni();
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				break;
			case 72:
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				break;
			case 73:
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				break;
			case 77:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-20);
				break;
			case 78:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
