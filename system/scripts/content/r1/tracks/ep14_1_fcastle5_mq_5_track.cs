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

[TrackScript("EP14_1_FCASTLE5_MQ_5_TRACK")]
public class EP141FCASTLE5MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_5_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(104.89,3.30,-298.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(103.9727f, 3.300003f, -299.5971f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150287, "", "ep14_1_f_castle_5", 516.5445, 3.300003, 15.81962, 78.75, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 470;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 5.872566, 3.300001, -458.5107, 71.15385, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 470;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 25.41744, 3.300003, -408.2957, 83.84615, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 470;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 16.24615, 3.300003, -341.635, 88.84616, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 470;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 89.68849, 3.300003, -370.368, 67.69231, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 470;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 136.5616, 3.300003, -408.6721, 81.53847, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 470;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 220.6006, 3.300003, -435.907, 64.23077, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 470;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 175.6806, 3.300003, -359.0164, 79.23077, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 470;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 263.1977, 3.300003, -393.3051, 65.76923, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 470;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 245.1564, 3.300003, -480.2363, 64.23077, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 470;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 116.1259, 3.300003, -445.9508, 60.38462, "Our_Forces");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.Level = 470;
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 564.4211, 3.300003, -37.02438, 90.76923, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.Level = 470;
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 571.9637, 3.300003, -4.79895, 101.9231, "Our_Forces");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.Level = 470;
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 555.3224, 3.300003, 51.60965, 63.46154, "Our_Forces");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.Level = 470;
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 617.1633, 3.300003, -33.28884, 66.53847, "Our_Forces");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.Level = 470;
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 572.683, 3.300003, 95.8237, 82.69231, "Our_Forces");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.Level = 470;
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 591.3727, 3.300003, 30.33559, 131.1539, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.Level = 470;
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 614.2263, 3.300003, 54.25253, 142.3077, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.Level = 470;
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 574.0445, 3.300003, -124.882, 70.38462, "Our_Forces");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.Level = 470;
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 547.0824, 3.300003, -70.94535, 58.84616, "Our_Forces");
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.Level = 470;
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 595.3251, 3.300003, -86.06227, 90.76923, "Our_Forces");
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.Level = 470;
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_SETPOS();
				break;
			case 30:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_5_TRACK_DLG1");
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_1_FCASTLE5_MQ_5_MGAME");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_PainBarrier_Buff");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
