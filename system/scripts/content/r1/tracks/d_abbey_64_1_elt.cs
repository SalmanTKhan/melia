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

[TrackScript("d_abbey_64_1_elt")]
public class dabbey641elt : TrackScript
{
	protected override void Load()
	{
		SetId("d_abbey_64_1_elt");
		//SetMap("d_abbey_64_1");
		//CenterPos(523.07,208.48,-1494.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(517.7115f, 208.4771f, -1496.718f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153100, "", "d_abbey_64_1", 491.3924, 95.95026, -604.9543, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153098, "", "d_abbey_64_1", 483.6889, 32.21509, 60.88666, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153099, "", "d_abbey_64_1", 459.4459, 32.21509, 333.407, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153097, "", "d_abbey_64_1", 477.8534, 83.42438, 537.5554, 38.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 12082, "", "d_abbey_64_1", 574.027, 208.4771, -1716.816, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 12082, "", "d_abbey_64_1", 472.3209, 9.310562, 575.8885, 0.5102041);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "d_abbey_64_1", 469.9095, 2.345154, 603.3673, 0.5102041);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 12082, "", "d_abbey_64_1", 474.6636, 2.345154, 622.8945, 0.5102041);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 153097, "", "d_abbey_64_1", 505.0396, 208.4771, -1471.097, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061", "BOT");
				break;
			case 46:
				//DRT_JUMP_TO_POS(0.1, 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061", "BOT");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061", "BOT");
				break;
			case 51:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
