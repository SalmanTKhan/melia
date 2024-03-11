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

[TrackScript("d_limestonecave_52_1_elt")]
public class dlimestonecave521elt : TrackScript
{
	protected override void Load()
	{
		SetId("d_limestonecave_52_1_elt");
		//SetMap("d_limestonecave_52_1");
		//CenterPos(531.98,-404.91,775.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(531.9834f, -404.91f, 775.8079f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157023, "", "d_limestonecave_52_1", 367.5, -459.08, 703.7, 6);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 40070, "", "d_limestonecave_52_1", 504.8382, -404.91, 788.6441, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				//DRT_JUMP_TO_POS(0.6, 250);
				break;
			case 190:
				//DRT_JUMP_TO_POS(0.6, 250);
				break;
			case 194:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
