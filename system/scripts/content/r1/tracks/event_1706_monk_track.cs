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

[TrackScript("EVENT_1706_MONK_TRACK")]
public class EVENT1706MONKTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EVENT_1706_MONK_TRACK");
		//SetMap("None");
		//CenterPos(-396.37,148.82,-96.93);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-375.3476f, 148.8223f, -117.588f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147513, "", "None", -391, 148, -132, 1);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147514, "", "None", -277.5984, 148.8227, -74.4977, 3.333333);
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
				await track.Dialog.Msg("EVENT_1706_MONK_DLG1");
				break;
			case 13:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG2");
				break;
			case 15:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG3");
				break;
			case 17:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG4");
				break;
			case 19:
				await track.Dialog.Msg("EVENT_1706_MONK_DLG5");
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
