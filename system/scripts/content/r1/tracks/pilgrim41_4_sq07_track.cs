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

[TrackScript("PILGRIM41_4_SQ07_TRACK")]
public class PILGRIM414SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_4_SQ07_TRACK");
		//SetMap("f_pilgrimroad_41_4");
		//CenterPos(1167.86,-37.23,325.74);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1169.318f, -37.22958f, 321.238f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155035, "", "f_pilgrimroad_41_4", 1174.7, -37.23, 334.89, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155045, "", "f_pilgrimroad_41_4", 1222, -37.23, 334.25, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155122, "", "f_pilgrimroad_41_4", 1190.024, -37.22958, 338.1633, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155037, "", "f_pilgrimroad_41_4", 1121.623, -37.22958, 372.6364, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155036, "", "f_pilgrimroad_41_4", 1245.94, -37.23, 394.72, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155034, "", "f_pilgrimroad_41_4", 1327.37, -37.23, 329.52, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke012_dark2", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke025_spread_out", "BOT");
				break;
			case 69:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 70:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
