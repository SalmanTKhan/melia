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

[TrackScript("PILGRIM46_SQ_089_TRACK")]
public class PILGRIM46SQ089TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM46_SQ_089_TRACK");
		//SetMap("f_pilgrimroad_46");
		//CenterPos(45.47,120.40,690.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155035, "", "f_pilgrimroad_46", 1.07, 120.4, 699.84, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155039, "UnvisibleName", "f_pilgrimroad_46", 37.38832, 120.4043, 466.8542, 86.42857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155027, "UnvisibleName", "f_pilgrimroad_46", -58.6902, 120.4043, 633.4893, 1);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(47.54841f, 120.4043f, 703.6646f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 155039, "", "f_pilgrimroad_46", -2.080307, 120.4043, 565.1604, 73.88889);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 25:
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
