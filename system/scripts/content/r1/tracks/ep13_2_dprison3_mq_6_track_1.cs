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

[TrackScript("EP13_2_DPRISON3_MQ_6_TRACK_1")]
public class EP132DPRISON3MQ6TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_6_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(-133.00,10.10,829.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-132.9958f, 10.10006f, 829.7682f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59658, "", "ep13_2_d_prison_3", -442.5015, 10.10006, 621.1152, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "ep13_2_d_prison_3", -512.0227, 10.10006, 1119.203, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59663, "", "ep13_2_d_prison_3", -648.4814, 10.10006, 347.3725, 100);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59663, "", "ep13_2_d_prison_3", -102.4269, 10.10006, 824.0772, 97.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", -297.5482, 10.10006, 415.4435, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", -226.8607, 10.10006, 513.0238, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", -497.6694, 10.10006, 557.4694, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", -432.4581, 10.10006, 709.6196, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_only_quest_arrow008", "arrow_cast", "F_only_quest_spark013", "arrow_blow", "FAST", 1000, 0, 0, 1, 0, 0);
				break;
			case 35:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG1");
				break;
			case 36:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG2");
				break;
			case 37:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG3");
				break;
			case 38:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG4");
				break;
			case 39:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG5");
				break;
			case 40:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG6");
				break;
			case 41:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_6_TRACK_DLG7");
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_spark013", "MID", 0);
				break;
			case 58:
				break;
			case 64:
				break;
			case 77:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_6_MGAME_1");
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
