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

[TrackScript("EP13_F_SIAULIAI_4_MQ07_TRACK")]
public class EP13FSIAULIAI4MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_4_MQ07_TRACK");
		//SetMap("ep13_f_siauliai_4");
		//CenterPos(543.87,79.91,-145.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(584.9941f, 79.90745f, -155.2337f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -300.6377, 10.58293, 896.3751, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -300.5605, 10.66588, 867.7327, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -270.8924, 10.37325, 883.8057, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -298.0338, 10.66607, 835.275, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -266.2888, 10.66574, 851.8008, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "ep13_f_siauliai_4", -297.6782, 10.6662, 811.5828, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_4", -620.1623, 79.90746, -201.5144, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_4", -195.558, 10.66575, 693.4989, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "ep13_f_siauliai_4", 830.7346, 79.90747, 555.9006, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_4", 795.3214, 79.90746, 372.083, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_4", 751.6539, 79.90762, 611.2072, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_4", 1053.304, 79.90749, 574.8379, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_4", 780.5399, 79.90765, 640.0891, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_4", 821.3651, 79.90746, 405.868, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_4", 1022.086, 79.90746, 545.2146, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_4", 751.6893, 79.90753, 575.2684, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_4", 1021.958, 79.90746, 499.6418, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59589, "", "ep13_f_siauliai_4", 308.2523, 10.67327, 722.5963, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", 205.5556, 10.66559, 740.9545, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", 235.4682, 10.66464, 871.6246, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 59589, "", "ep13_f_siauliai_4", 306.0297, 10.66502, 810.9103, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 59588, "", "ep13_f_siauliai_4", 367.9733, 14.65238, 707.7628, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 59588, "", "ep13_f_siauliai_4", 424.4262, 45.25557, 695.2828, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", -391.941, 10.70994, 547.5944, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", -329.7004, 10.72814, 513.8937, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", -350.2933, 10.69608, 567.1687, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 59587, "", "ep13_f_siauliai_4", -337.9684, 10.66697, 609.1064, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 28:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_4_MQ07_TRACK1", 3);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 48:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 62:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 64:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 65:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 66:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 72:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 75:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				break;
			case 76:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 77:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke150_white", "BOT");
				break;
			case 78:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 80:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 81:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 82:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke150_white", "BOT");
				break;
			case 84:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				break;
			case 85:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 87:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				break;
			case 88:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke150_white", "BOT");
				break;
			case 89:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke169_shockwave_red_2", "BOT");
				break;
			case 91:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 92:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 94:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 95:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 96:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 97:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 99:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 100:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 102:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 104:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_4_MQ07_TRACK4", 3);
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 105:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 106:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 108:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 109:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 111:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 112:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 113:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 114:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 115:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
