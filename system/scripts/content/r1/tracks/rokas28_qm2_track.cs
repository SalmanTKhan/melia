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

[TrackScript("ROKAS28_QM2_TRACK")]
public class ROKAS28QM2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS28_QM2_TRACK");
		//SetMap("d_zachariel_32");
		//CenterPos(1265.26,267.33,-2195.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 45324, "", "d_zachariel_32", 1474.381, 267.3323, -2200.649, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1271f, 267f, -2202f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_light003_green", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation022_light", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
