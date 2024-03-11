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

[TrackScript("d_underfortress_59_3_TRACK")]
public class dunderfortress593TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("d_underfortress_59_3_TRACK");
		//SetMap("None");
		//CenterPos(1395.07,-107.78,971.53);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 12082, "", "None", 1403.639, -107.6847, 1114.401, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 740015, "UnvisibleName", "None", 1390.48, -107.6867, 1117.087, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 740000, "", "None", 1389.775, -107.6867, 1117.371, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58421, "", "None", 1243.558, -107.6255, 1185.89, 33);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58421, "", "None", 1370.141, -107.6194, 1261.477, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58421, "", "None", 1337.18, -107.6777, 1153.354, 29.54545);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58421, "", "None", 1461.36, -107.6194, 1216.921, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 12082, "", "None", 1388.878, -107.6939, 1107.249, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 12082, "", "None", 1390.398, -107.6955, 1104.33, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 12082, "", "None", 1385.845, -107.6883, 1116.86, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 12082, "", "None", 1384.171, -107.6853, 1121.894, 140);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 12082, "", "None", 1378.688, -107.6935, 1112.34, 0);
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
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab03_mash##2.5", "BOT");
				//DRT_ACTOR_PLAY_EFT("I_EventVab02_mash##2", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##2", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##1", "BOT");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_EventVab02_mash##1", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##1", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##3", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##3", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##1", "BOT");
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("I_EventVab02_mash##1", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash##1", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab04_mash##6", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke126", "BOT");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("I_EventVab_mash##3", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_earthwave_shot_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light097_red", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_warcry_shot_smoke", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red_noloop", "BOT");
				break;
			case 43:
				break;
			case 46:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
