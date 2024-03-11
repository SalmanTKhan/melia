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

[TrackScript("d_cmine_66_2_cart2")]
public class dcmine662cart2 : TrackScript
{
	protected override void Load()
	{
		SetId("d_cmine_66_2_cart2");
		//SetMap("d_cmine_66_2");
		//CenterPos(242.39,511.44,989.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(242.3925f, 511.4362f, 989.9639f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155114, "UnVisibleName", "d_cmine_66_2", 283.1248, 511.4362, 992.0666, 0);
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
			case 10:
				//DRT_JUMP_TO_POS(0.5, 250);
				break;
			case 36:
				//DRT_JUMP_TO_POS(0.5, 300);
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
