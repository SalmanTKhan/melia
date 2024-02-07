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

[TrackScript("EP14_1_FCASTLE5_MQ_6_TRACK")]
public class EP141FCASTLE5MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_6_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(143.93,65.33,1020.04);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(148.3596f, 65.33099f, 1062.906f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", 218.6774, 65.33099, 1269.243, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59708, "", "ep14_1_f_castle_5", 245.8436, 65.33099, 1159.046, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_5", 572.5108, 82.17256, 1276.888, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 1000;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 37.57143, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 470;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 31, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 470;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 48.28571, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 470;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 35.42857, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 470;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 23.85714, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 470;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 39.85714, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 470;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 48.14286, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 470;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 44.85714, "Our_Forces");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.Level = 470;
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 657.7669, 111.687, 1293.666, 57.71429, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.Level = 470;
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 156.7774, 65.33099, 985.1916, 0, "Our_Forces");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.Level = 470;
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 108.5576, 65.33099, 1000.269, 0, "Our_Forces");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.Level = 470;
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 128.7014, 65.33099, 956.3835, 0, "Our_Forces");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.Level = 470;
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 53.82207, 65.33099, 1006.104, 0, "Our_Forces");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.Level = 470;
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 192.3273, 65.33098, 947.8937, 0, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.Level = 470;
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 70.56405, 65.33099, 959.8405, 0, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.Level = 470;
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 71.40389, 65.33099, 1050.161, 0, "Our_Forces");
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
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 19:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008#Bip01 R Finger11", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0, 0, 1, 10, 0);
				break;
			case 37:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_6_TRACK_DLG1");
				break;
			case 39:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE5_MQ_6_MGAME");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_PainBarrier_Buff");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
