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

[TrackScript("LOWLV_EYEOFBAIGA_SQ_20_TRACK")]
public class LOWLVEYEOFBAIGASQ20TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LOWLV_EYEOFBAIGA_SQ_20_TRACK");
		//SetMap("d_velniasprison_51_1");
		//CenterPos(429.10,346.15,1365.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(521.1103f, 346.1506f, 1425.002f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 46214, "", "d_velniasprison_51_1", 535.6258, 346.1506, 1425.377, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
