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

[TrackScript("MASTER_LANCER_1_TRACK")]
public class MASTERLANCER1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MASTER_LANCER_1_TRACK");
		//SetMap("f_maple_25_1");
		//CenterPos(154.27,-68.53,14.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(154.872f, -68.53253f, 14.97223f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157012, "UnvisibleName", "f_maple_25_1", 141.9301, -68.53253, -2.153214, 283.3333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 46011, "UnvisibleName", "f_maple_25_1", 151.7812, -68.53253, 41.70795, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob1 = Shortcuts.AddMonster(0, 147375, "UnvisibleName", "f_maple_25_1", 77.21733, -68.53253, 51.75086, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58539, "", "f_maple_25_1", 34.96421, -68.53253, 265.7134, 76.66666);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 285;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58539, "", "f_maple_25_1", 371.101, -70.09956, 212.4953, 35);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 285;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58538, "", "f_maple_25_1", 290.988, -68.53253, 244.9766, 55.625);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 285;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58538, "", "f_maple_25_1", 158.2552, -68.53253, 250.6116, 50);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 285;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58539, "", "f_maple_25_1", 208.8646, -68.53253, 403.9919, 80);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58538, "", "f_maple_25_1", 82.83305, -68.53253, 386.4966, 97.5);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58539, "", "f_maple_25_1", 320.7585, -70.12685, 377.9487, 65);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 58538, "", "f_maple_25_1", 411.8179, -92.65742, 328.9547, 115);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				character.AddonMessage("NOTICE_Dm_scroll", "The grass is emitting an evil energy", 3);
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark4", "BOT", 0);
				break;
			case 11:
				//TRACK_MON_LOOKAT();
				break;
			case 14:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
