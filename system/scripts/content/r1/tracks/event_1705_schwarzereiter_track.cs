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

[TrackScript("EVENT_1705_SCHWARZEREITER_TRACK")]
public class EVENT1705SCHWARZEREITERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EVENT_1705_SCHWARZEREITER_TRACK");
		//SetMap("c_Klaipe");
		//CenterPos(-11.42,148.83,306.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(64.85198f, 148.8296f, 364.3736f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147510, "", "c_Klaipe", 83, 148, 383, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57236, "", "c_Klaipe", 1.821192, 148.8461, 463.7768, 34.5);
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
			case 5:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG1");
				break;
			case 9:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG2");
				break;
			case 11:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG3");
				break;
			case 13:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG4");
				break;
			case 15:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG5");
				break;
			case 17:
				await track.Dialog.Msg("EVENT_1705_SCHWARZEREITER_DLG6");
				break;
			case 22:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
