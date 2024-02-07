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

[TrackScript("EP14_1_FCASTLE4_MQ_1_TRACK")]
public class EP141FCASTLE4MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_4");
		//CenterPos(1184.84,58.91,-1828.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1176.084f, 58.91404f, -1831.275f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_4", 1243.006, 58.91404, -1392.411, 0.75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_4", 1210.108, 58.91404, -1342.533, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_4", 1269.217, 58.91404, -1351.327, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1110.879, 58.91404, -1376.924, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1382.845, 58.91404, -1309.471, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1370.782, 58.91404, -1450.953, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1163.849, 58.91404, -1361.47, 13.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1134.536, 58.91404, -1458.465, 2.75);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1259.527, 58.91404, -1176.179, 5);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1176.667, 58.91404, -1423.356, 3.5);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1405.866, 58.91404, -1393.754, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1331.671, 58.91404, -1380.551, 5.5);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1237.541, 58.91404, -1262.065, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1152.292, 58.91404, -1236.241, 13);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1295.869, 58.91404, -1515.406, 2.5);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1310.194, 58.91404, -1150.64, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1201.094, 58.91404, -1525.525, 5);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1309.039, 58.91404, -1299.074, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1303.793, 58.91404, -1452.24, 1.25);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1059.724, 58.91404, -1404.453, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1386.421, 58.91404, -1244.276, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1227.841, 58.91404, -1469.71, 4.25);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1368.88, 58.91404, -1516.199, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1203.299, 58.91404, -1195.212, 6.5);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1144.598, 58.91404, -1303.815, 11.5);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1319.907, 58.91404, -1232.463, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1124.757, 58.91404, -1150.062, 10);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1079.305, -29.89576, -5.509987, 75.88235);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1304.965, -29.89576, -157.3126, 43.52941);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1269.606, -29.89576, -12.54464, 57.64706);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1033.726, -29.89576, -80.95006, 41.76471);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 1197.8, -29.89576, -52.02074, 39.11765);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008##0.2", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0, 0, 0, 0, 0);
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008##0.2", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0, 0, 0, 0, 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_spread_in053_dark", "MID", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 55:
				Send.ZC_NORMAL.Notice(character, "EP14_1_FCASTLE4_MQ_1_TRACK_DLG1", 1);
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_explosion140_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke101_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_levitation020_dark", "MID", 0);
				break;
			case 81:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_1_TRACK_DLG2");
				break;
			case 82:
				break;
			case 93:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_1_TRACK_DLG3");
				break;
			case 99:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE4_MQ_1_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
