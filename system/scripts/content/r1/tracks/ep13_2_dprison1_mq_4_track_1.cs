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

[TrackScript("EP13_2_DPRISON1_MQ_4_TRACK_1")]
public class EP132DPRISON1MQ4TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_4_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(1677.68,209.80,468.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1672.331f, 209.8f, 462.8229f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", 1679.242, 199.0001, 777.3839, 39.5, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59665, "", "ep13_2_d_prison_1", 1781.507, 199.0001, 1291.081, 67.16666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59667, "", "ep13_2_d_prison_1", 1781.507, 199.0001, 1291.081, 62.16667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59667, "", "ep13_2_d_prison_1", 1781.507, 199.0001, 1291.081, 57.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON1_MQ_4_DLG1", 5);
				break;
			case 40:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//DRT_PLAY_MGAME("EP13_2_DPRISON1_MQ_4_MGAME_1");
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "Stop the monsters and chase the Beholder!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
