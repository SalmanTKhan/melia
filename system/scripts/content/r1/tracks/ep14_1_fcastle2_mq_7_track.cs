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

[TrackScript("EP14_1_FCASTLE2_MQ_7_TRACK")]
public class EP141FCASTLE2MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE2_MQ_7_TRACK");
		//SetMap("ep14_1_f_castle_2");
		//CenterPos(562.86,102.13,801.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(560.2479f, 102.2068f, 804.2583f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59696, "", "ep14_1_f_castle_2", 888.7336, 104.2862, 1132.353, 44.375);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 839.469, 104.2862, 1028.794, 34);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 835.2888, 104.2862, 1086.19, 40);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 836.346, 104.2862, 1137.775, 41);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 834.5822, 104.2862, 1189.478, 45.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 832.2536, 104.2862, 1250.05, 49);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 772.0251, 104.2862, 1030.267, 35.41666);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 770.0533, 104.2862, 1088.206, 41.25);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 765.6817, 104.2862, 1141.879, 45.83333);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 773.0937, 104.2862, 1195.896, 42.91666);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 771.6799, 104.2862, 1248.706, 43.33333);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 690.0865, 104.2862, 1039.129, 41.42857);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 695.7915, 104.2862, 1095.001, 43.92857);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 700.8739, 104.2862, 1149.119, 41.42857);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 706.8498, 104.2862, 1201.265, 40.71429);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 703.3799, 104.2862, 1258.977, 43.57143);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_2", 1495.763, 88.33621, 1105.024, 0, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.Level = 470;
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_2", 1542.467, 77.3259, 1135.592, 0, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.Level = 470;
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_2", 1527.333, 77.3259, 1056.824, 0, "Our_Forces");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.Level = 470;
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 36:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE1_MQ_7_SOLDIER_SET");
				//DRT_FACTIONCHANGE("Our_Forces");
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//DRT_FACTIONCHANGE("Our_Forces");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE1_MQ_7_SOLDIER_SET");
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE1_MQ_7_SOLDIER_SET");
				//DRT_FACTIONCHANGE("Our_Forces");
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 39:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE2_MQ_7_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
