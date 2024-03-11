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

[TrackScript("ACT2_DISS1_2_BOSS_TRACK")]
public class ACT2DISS12BOSSTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ACT2_DISS1_2_BOSS_TRACK");
		//SetMap("f_siauliai_2");
		//CenterPos(661.13,130.02,-475.52);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41210, "", "f_siauliai_2", -40.45959, 101.3127, -551.6553, 611.6666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 7;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 199.2247, 130.0327, -649.9623, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 6;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 211.9808, 130.0327, -597.4641, 14.75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 6;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 263.824, 130.0327, -682.1984, 15);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 6;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 210.1192, 130.0327, -575.4683, 10.68182);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 6;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 306.948, 130.0327, -650.9565, 3.333333);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 6;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400961, "", "f_siauliai_2", 268.3602, 130.0327, -602.1815, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 6;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20016, "", "f_siauliai_2", 661.2861, 130.0227, -453.1161, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 153056, "UnvisibleName", "f_siauliai_2", 484.2077, 130.0227, -515.7422, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 153056, "UnvisibleName", "f_siauliai_2", 484.5967, 130.0227, -475.6516, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 153056, "UnvisibleName", "f_siauliai_2", 584.4737, 130.0227, -449.4077, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		character.Movement.MoveTo(new Position(670.4318f, 130.0227f, -473.4785f));
		actors.Add(character);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "f_siauliai_2", -41.61682, 101.3127, -532.2244, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup043_water_blue", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup041_water_blue_reverse", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup041_water_blue", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground115_water", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground115_water", "BOT");
				break;
			case 32:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
