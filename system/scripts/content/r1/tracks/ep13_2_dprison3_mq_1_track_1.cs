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

[TrackScript("EP13_2_DPRISON3_MQ_1_TRACK_1")]
public class EP132DPRISON3MQ1TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_1_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(659.49,10.10,-1016.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(659.4856f, 10.10006f, -1016.403f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59658, "", "ep13_2_d_prison_3", 289.5312, 10.10006, -762.7341, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_3", 352.7437, 10.10006, -830.1985, 15.2);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47273, "", "ep13_2_d_prison_3", 340.8566, 10.10006, -857.0654, 0);
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
			case 18:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG1");
				break;
			case 20:
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG2");
				break;
			case 42:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_1_TRACK_DLG3");
				break;
			case 59:
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_1_MGAME_1");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
