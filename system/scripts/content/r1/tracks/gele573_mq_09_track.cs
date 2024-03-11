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

[TrackScript("GELE573_MQ_09_TRACK")]
public class GELE573MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE573_MQ_09_TRACK");
		//SetMap("f_gele_57_3");
		//CenterPos(140.07,350.07,-80.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 57223, "", "f_gele_57_3", 62.44534, 350.0658, -135.5797, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 147373, "", "f_gele_57_3", 66.95541, 350.0658, -155.8456, 0);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var mob0 = Shortcuts.AddMonster(0, 57094, "Throneweaver", "f_gele_57_3", 158.1813, 350.0758, -410.4033, 49.64286);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", -50.30015, 350.2022, -445.5872, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", 29.13335, 350.0758, -472.9453, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", 151.7193, 350.0758, -417.5872, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", 65.14674, 350.0758, -457.2352, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", -36.42421, 350.0758, -451.9175, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", 55.10651, 350.0758, -456.7933, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 41280, "", "f_gele_57_3", 174.9166, 350.0758, -405.1172, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		character.Movement.MoveTo(new Position(75.60583f, 350.0658f, -128.1865f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere001_green_loop", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere001_green_loop", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere001_green_loop", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere001_green_loop", "BOT");
				break;
			case 19:
				break;
			case 20:
				break;
			case 21:
				break;
			case 24:
				break;
			case 26:
				break;
			case 31:
				break;
			case 32:
				break;
			case 44:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
