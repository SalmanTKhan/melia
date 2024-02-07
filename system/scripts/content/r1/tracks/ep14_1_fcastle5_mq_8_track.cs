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

[TrackScript("EP14_1_FCASTLE5_MQ_8_TRACK")]
public class EP141FCASTLE5MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_8_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(-811.43,190.30,929.01);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-812.3411f, 190.3f, 929.1378f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_5", -732.1326, 190.3, 939.9602, 92.85715, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 1000;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150287, "", "ep14_1_f_castle_5", -592.5197, 180.745, 46.55036, 11.25, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 1000;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -870.7858, 190.3, 1092.13, 80, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 470;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -859.7443, 190.3, 973.8285, 98.57143, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 470;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -639.7267, 190.3, 1084.131, 150.7143, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 470;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -660.9028, 190.3, 955.6332, 102.8571, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 470;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -825.9412, 190.3, 1013.445, 102.1429, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 470;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -947.1685, 190.3, 1071.593, 0, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 470;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -830.0283, 190.3, 1054.333, 65, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 470;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -594.0472, 190.3, 1031.206, 95, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 470;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -716.4116, 190.3, 1092.45, 107.8571, "Our_Forces");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.Level = 470;
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -638.2085, 190.3, 1012.347, 112.8571, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.Level = 470;
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -923.9227, 190.3, 999.3435, 0, "Our_Forces");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.Level = 470;
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -786.0432, 190.3, 963.379, 87.14286, "Our_Forces");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.Level = 470;
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -717.327, 190.3, 1043.447, 135.7143, "Our_Forces");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.Level = 470;
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -778.9547, 190.3, 1088.123, 117.1429, "Our_Forces");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.Level = 470;
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -754.5503, 190.3, 1012.406, 87.85715, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.Level = 470;
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -885.6807, 190.3, 1045.153, 87.14286, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.Level = 470;
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -605.1824, 180.745, -25.13981, 22.30769, "Our_Forces");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.Level = 470;
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -612.471, 180.745, 87.19417, 23.07692, "Our_Forces");
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.Level = 470;
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -613.021, 180.745, 42.64044, 27.30769, "Our_Forces");
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.Level = 470;
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -561.7065, 180.745, 36.02579, 31.53846, "Our_Forces");
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.Level = 470;
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -575.9407, 180.745, 99.59297, 31.15385, "Our_Forces");
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.Level = 470;
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -481.7052, 170.4726, 30.3164, 42.69231, "Our_Forces");
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.Level = 470;
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -583.4754, 180.745, -4.642282, 35, "Our_Forces");
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.Level = 470;
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -507.5424, 180.745, 14.20505, 53.07692, "Our_Forces");
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.Level = 470;
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -499.1985, 180.295, 53.29191, 42.69231, "Our_Forces");
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.Level = 470;
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", -530.6197, 180.745, 52.14627, 34.61539, "Our_Forces");
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.Level = 470;
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -865.8255, 180.745, -48.26347, 0);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -1010.724, 180.745, 276.6652, 0);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -1044.077, 180.745, 125.1136, 0);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -1092.786, 180.745, -23.37468, 0);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		var mob32 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -840.1328, 180.745, 429.5074, 0);
		mob32.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob32.AddEffect(new ScriptInvisibleEffect());
		mob32.Layer = character.Layer;
		actors.Add(mob32);

		var mob33 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -979.4944, 180.745, -230.3557, 0);
		mob33.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob33.AddEffect(new ScriptInvisibleEffect());
		mob33.Layer = character.Layer;
		actors.Add(mob33);

		var mob34 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -688.0748, 180.745, 364.9469, 0);
		mob34.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob34.AddEffect(new ScriptInvisibleEffect());
		mob34.Layer = character.Layer;
		actors.Add(mob34);

		var mob35 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -989.8694, 180.745, -9.581768, 0);
		mob35.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob35.AddEffect(new ScriptInvisibleEffect());
		mob35.Layer = character.Layer;
		actors.Add(mob35);

		var mob36 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -707.8491, 180.745, -197.6746, 0);
		mob36.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob36.AddEffect(new ScriptInvisibleEffect());
		mob36.Layer = character.Layer;
		actors.Add(mob36);

		var mob37 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -798.9675, 180.745, 32.98472, 0);
		mob37.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob37.AddEffect(new ScriptInvisibleEffect());
		mob37.Layer = character.Layer;
		actors.Add(mob37);

		var mob38 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -894.0529, 180.745, -284.7503, 0);
		mob38.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob38.AddEffect(new ScriptInvisibleEffect());
		mob38.Layer = character.Layer;
		actors.Add(mob38);

		var mob39 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -1133.681, 180.745, 287.9955, 0);
		mob39.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob39.AddEffect(new ScriptInvisibleEffect());
		mob39.Layer = character.Layer;
		actors.Add(mob39);

		var mob40 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -773.5792, 180.745, 252.0042, 0);
		mob40.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob40.AddEffect(new ScriptInvisibleEffect());
		mob40.Layer = character.Layer;
		actors.Add(mob40);

		var mob41 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -943.5009, 180.745, 47.81537, 0);
		mob41.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob41.AddEffect(new ScriptInvisibleEffect());
		mob41.Layer = character.Layer;
		actors.Add(mob41);

		var mob42 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -1067.92, 180.745, -164.3726, 0);
		mob42.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob42.AddEffect(new ScriptInvisibleEffect());
		mob42.Layer = character.Layer;
		actors.Add(mob42);

		var mob43 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -746.0894, 180.745, -277.2422, 0);
		mob43.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob43.AddEffect(new ScriptInvisibleEffect());
		mob43.Layer = character.Layer;
		actors.Add(mob43);

		var mob44 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -1000.809, 180.745, -100.0946, 0);
		mob44.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob44.AddEffect(new ScriptInvisibleEffect());
		mob44.Layer = character.Layer;
		actors.Add(mob44);

		var mob45 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -1036.003, 180.745, 426.1167, 0);
		mob45.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob45.AddEffect(new ScriptInvisibleEffect());
		mob45.Layer = character.Layer;
		actors.Add(mob45);

		var mob46 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -778.0117, 180.745, -55.27403, 0);
		mob46.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob46.AddEffect(new ScriptInvisibleEffect());
		mob46.Layer = character.Layer;
		actors.Add(mob46);

		var mob47 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -937.1852, 180.745, 411.4145, 0);
		mob47.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob47.AddEffect(new ScriptInvisibleEffect());
		mob47.Layer = character.Layer;
		actors.Add(mob47);

		var mob48 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -745.5436, 180.745, 318.511, 0);
		mob48.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob48.AddEffect(new ScriptInvisibleEffect());
		mob48.Layer = character.Layer;
		actors.Add(mob48);

		var mob49 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -766.4048, 180.745, -123.4496, 0);
		mob49.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob49.AddEffect(new ScriptInvisibleEffect());
		mob49.Layer = character.Layer;
		actors.Add(mob49);

		var mob50 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -974.653, 180.745, 145.4238, 0);
		mob50.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob50.AddEffect(new ScriptInvisibleEffect());
		mob50.Layer = character.Layer;
		actors.Add(mob50);

		var mob51 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -838.0021, 180.745, 107.509, 0);
		mob51.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob51.AddEffect(new ScriptInvisibleEffect());
		mob51.Layer = character.Layer;
		actors.Add(mob51);

		var mob52 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -1141.616, 180.745, 98.87182, 0);
		mob52.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob52.AddEffect(new ScriptInvisibleEffect());
		mob52.Layer = character.Layer;
		actors.Add(mob52);

		var mob53 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -862.7537, 180.745, -209.9283, 0);
		mob53.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob53.AddEffect(new ScriptInvisibleEffect());
		mob53.Layer = character.Layer;
		actors.Add(mob53);

		var mob54 = Shortcuts.AddMonster(0, 59707, "", "ep14_1_f_castle_5", -917.4042, 180.745, 311.6871, 0);
		mob54.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob54.AddEffect(new ScriptInvisibleEffect());
		mob54.Layer = character.Layer;
		actors.Add(mob54);

		var mob55 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -867.9872, 180.745, -132.0927, 0);
		mob55.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob55.AddEffect(new ScriptInvisibleEffect());
		mob55.Layer = character.Layer;
		actors.Add(mob55);

		var mob56 = Shortcuts.AddMonster(0, 59706, "", "ep14_1_f_castle_5", -794.6011, 180.745, 160.0229, 0);
		mob56.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob56.AddEffect(new ScriptInvisibleEffect());
		mob56.Layer = character.Layer;
		actors.Add(mob56);

		var mob57 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", -908.1088, 180.745, 224.3609, 0);
		mob57.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob57.AddEffect(new ScriptInvisibleEffect());
		mob57.Layer = character.Layer;
		actors.Add(mob57);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_SETPOS();
				break;
			case 25:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_8_TRACK_DLG1");
				break;
			case 34:
				//DRT_PLAY_MGAME("EP14_1_FCASTLE5_MQ_8_MGAME");
				CreateBattleBoxInLayer(character, track);
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_PainBarrier_Buff");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_PainBarrier_Buff");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
