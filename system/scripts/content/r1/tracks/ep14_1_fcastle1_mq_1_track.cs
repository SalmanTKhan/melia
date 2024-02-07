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

[TrackScript("EP14_1_FCASTLE1_MQ_1_TRACK")]
public class EP141FCASTLE1MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE1_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_1");
		//CenterPos(1460.56,0.48,-748.80);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1460.564f, 0.4795074f, -748.8047f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147326, "", "ep14_1_f_castle_1", 1149.208, 0.4795026, -671.2283, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 470;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_1", 1174.872, 0.4795026, -643.4759, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_1", 1092.498, 0.4795009, -645.7555, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_1", 1112.471, 0.4795036, -595.5453, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1088.698, 0.4795074, -529.7439, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1261.831, 0.4795072, -675.0269, 268);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1175.163, 0.4795063, -722.5989, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59693, "", "ep14_1_f_castle_1", 1216.325, 0.479505, -582.9073, 140);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1058.342, 0.4795036, -673.971, 13);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1211.951, 0.4795037, -637.0206, 30);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59693, "", "ep14_1_f_castle_1", 1061.418, 0.4795053, -592.6176, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1147.558, 0.4795054, -551.7469, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1224.599, 0.4795097, -743.192, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59693, "", "ep14_1_f_castle_1", 1020.093, 0.4795065, -610.8693, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1127.41, 0.479504, -712.5313, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59693, "", "ep14_1_f_castle_1", 1204.875, 0.4795058, -690.1245, 10);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59692, "", "ep14_1_f_castle_1", 1040.011, 0.4795074, -543.9631, 162);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59693, "", "ep14_1_f_castle_1", 1141.332, 0.4795079, -775.4166, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_RUN_FUNCTION("SCR_EP14_1_SOLDIER_BTREESET");
				//DRT_RUN_FUNCTION("SCR_EP14_1_TRACKNPC_NODAMAGE");
				//DRT_RUN_FUNCTION("SCR_EP14_1_SOLDIER_BTREESET");
				//DRT_RUN_FUNCTION("SCR_EP14_1_TRACKNPC_NODAMAGE");
				//DRT_RUN_FUNCTION("SCR_EP14_1_SOLDIER_BTREESET");
				//DRT_RUN_FUNCTION("SCR_EP14_1_TRACKNPC_NODAMAGE");
				//DRT_RUN_FUNCTION("SCR_EP14_1_SOLDIER_BTREESET");
				//DRT_RUN_FUNCTION("SCR_EP14_1_TRACKNPC_NODAMAGE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
