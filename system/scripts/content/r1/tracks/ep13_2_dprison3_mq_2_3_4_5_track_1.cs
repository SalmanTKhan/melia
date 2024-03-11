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

[TrackScript("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_1")]
public class EP132DPRISON3MQ2345TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(701.74,10.10,-1001.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(702.0623f, 10.10006f, -1001.541f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47273, "", "ep13_2_d_prison_3", 711.7357, 10.10006, -973.9891, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_3", 742.9536, 10.10006, -969.1786, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47283, "", "ep13_2_d_prison_3", 223.4377, 15.93596, -548.6099, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG1");
				break;
			case 2:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG2");
				break;
			case 3:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG3");
				break;
			case 4:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG4");
				break;
			case 5:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG5");
				break;
			case 6:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG6");
				break;
			case 13:
				break;
			case 20:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG8");
				break;
			case 21:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG7");
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON3_MQ_2_3_4_5_TRACK_DLG9", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
