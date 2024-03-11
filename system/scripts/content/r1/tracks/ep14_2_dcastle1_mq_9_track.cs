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

[TrackScript("EP14_2_DCASTLE1_MQ_9_TRACK")]
public class EP142DCASTLE1MQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE1_MQ_9_TRACK");
		//SetMap("ep14_2_d_castle_1");
		//CenterPos(-867.04,233.27,3274.71);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-665.7498f, 233.2691f, 3338.325f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150287, "", "ep14_2_d_castle_1", -662.1384, 233.2691, 3017.034, 58.8);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20060, "", "ep14_2_d_castle_1", -645.396, 233.2691, 2990.996, 59.375);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20060, "", "ep14_2_d_castle_1", -685.0731, 233.2691, 2992.884, 59.58333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 157115, "", "ep14_2_d_castle_1", -671.0585, 233.2691, 3362.666, 0.7142857);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154001, "", "ep14_2_d_castle_1", -908.5604, 233.2691, 3283.038, 0);
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
			case 8:
				break;
			case 10:
				break;
			case 77:
				await track.Dialog.Msg("EP14_2_DCASTLE1_MQ_9_DLG1");
				break;
			case 99:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
