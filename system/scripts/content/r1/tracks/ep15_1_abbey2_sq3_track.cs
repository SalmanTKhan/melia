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

[TrackScript("EP15_1_ABBEY2_SQ3_TRACK")]
public class EP151ABBEY2SQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_ABBEY2_SQ3_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(993.25,156.78,-176.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(993.2534f, 156.7779f, -176.3057f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155119, "", "ep15_1_f_abbey_2", 933.6531, 156.7779, -148.9707, 55.625);
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
			case 4:
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
