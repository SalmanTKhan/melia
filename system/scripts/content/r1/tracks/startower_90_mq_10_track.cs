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

[TrackScript("STARTOWER_90_MQ_10_TRACK")]
public class STARTOWER90MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_90_MQ_10_TRACK");
		//SetMap("d_startower_90");
		//CenterPos(1849.66,80.36,-905.01);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1848.145f, 80.63176f, -902.9828f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156120, "", "d_startower_90", 1740, 98, -860, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155165, "", "d_startower_90", 1747, 97, -974, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155163, "", "d_startower_90", 1700, 98, -866, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156127, "", "d_startower_90", 1685, 96, -978, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154065, "", "d_startower_90", 1761.346, 98.23797, -868.115, 10.83333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG1");
				break;
			case 14:
				//DRT_RUN_FUNCTION("SCR_D_STARTOWER_90_MQ_10_TRACK_ATTACH");
				break;
			case 27:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG2");
				break;
			case 28:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG3");
				break;
			case 29:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG4");
				break;
			case 35:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG5");
				break;
			case 36:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG6");
				break;
			case 37:
				await track.Dialog.Msg("STARTOWER_90_MQ_10_TRACK_DLG7");
				break;
			case 38:
				//DRT_RUN_FUNCTION("SCR_D_STARTOWER_90_MQ_10_TRACK_DETACH");
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
