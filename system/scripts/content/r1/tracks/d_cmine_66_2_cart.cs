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

[TrackScript("d_cmine_66_2_cart")]
public class dcmine662cart : TrackScript
{
	protected override void Load()
	{
		SetId("d_cmine_66_2_cart");
		//SetMap("d_cmine_66_2");
		//CenterPos(1102.04,511.44,-961.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1091.591f, 511.4362f, -958.6836f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155114, "UnVisibleName", "d_cmine_66_2", 1070.42, 511.4362, -964.6079, 0);
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
				//DRT_JUMP_TO_POS(0.6, 320);
				break;
			case 43:
				//DRT_JUMP_TO_POS(0.6, 300);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
