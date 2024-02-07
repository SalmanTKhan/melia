using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP14_2_DCASTLE3_MQ_6_TRACK")]
public class EP142DCASTLE3MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_6_TRACK");
		//SetMap("ep14_2_d_castle_3");
		//CenterPos(-11.77,105.10,1876.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1.28599f, 105.0999f, 1866.789f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154120, "", "ep14_2_d_castle_3", 27.52067, 105.0999, 1834.783, 3);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 160128, "", "ep14_2_d_castle_3", -38.51841, 105.0999, 1995.37, 0.7142857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150287, "", "ep14_2_d_castle_3", -17.73068, 105.0999, 1822.946, 0.2531646);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59657, "", "ep14_2_d_castle_3", -25.537, 105.0999, 1949.067, 2);
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
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_violet", "MID");
				break;
			case 45:
				//DRT_CLEAR_EFFECT();
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_violet", "MID");
				break;
			case 53:
				//DRT_CLEAR_EFFECT();
				break;
			case 99:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
