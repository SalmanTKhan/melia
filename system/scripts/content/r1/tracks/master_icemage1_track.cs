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

[TrackScript("MASTER_ICEMAGE1_TRACK")]
public class MASTERICEMAGE1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MASTER_ICEMAGE1_TRACK");
		//SetMap("c_firemage");
		//CenterPos(253.85,2.44,-0.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(195f, 3f, 5f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 40030, "Pyromancer", "c_firemage", -57, 7, -21, 0);
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
			case 1:
				Send.ZC_NORMAL.Notice(character, "MASTER_ICEMAGE_MONOLOGUE", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
