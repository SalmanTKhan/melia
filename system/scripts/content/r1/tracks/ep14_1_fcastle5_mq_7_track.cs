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

[TrackScript("EP14_1_FCASTLE5_MQ_7_TRACK")]
public class EP141FCASTLE5MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_7_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(-511.00,190.30,1226.39);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-510.5534f, 190.3f, 1226.835f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_5", -527.8992, 190.3, 1276.488, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 1000;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -448.823, 190.3, 1215.805, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 470;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -370.0468, 180.4869, 1311.617, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 470;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -380.9377, 186.8, 1262.654, 0, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 470;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -544.2136, 190.3, 1448.16, 0, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 470;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -415.0587, 190.3, 1336.092, 0, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 470;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -482.0782, 190.3, 1442.343, 0, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 470;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -436.7403, 190.3, 1300.636, 0, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 470;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -426.4926, 190.3, 1243.331, 0, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 470;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -597.119, 190.3, 1418.556, 0, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 470;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -484.1798, 190.3, 1298.863, 0, "Our_Forces");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.Level = 470;
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -518.9171, 190.3, 1381.648, 0, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.Level = 470;
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -477.3984, 190.3, 1365.591, 0, "Our_Forces");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.Level = 470;
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -551.8672, 190.3, 1339.061, 0, "Our_Forces");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.Level = 470;
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -433.393, 190.3, 1386.604, 0, "Our_Forces");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.Level = 470;
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -433.393, 190.3, 1386.604, 0, "Our_Forces");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.Level = 470;
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -433.393, 190.3, 1386.604, 158.3333, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.Level = 470;
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -433.393, 190.3, 1386.604, 175, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.Level = 470;
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -433.393, 190.3, 1386.604, 75, "Our_Forces");
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
			case 2:
				//DRT_SETPOS();
				break;
			case 24:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE5_MQ_7_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
