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

[TrackScript("EP13_F_SIAULIAI_5_MQ_03_TRACK")]
public class EP13FSIAULIAI5MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_5_MQ_03_TRACK");
		//SetMap("ep13_f_siauliai_5");
		//CenterPos(-252.19,17.22,-9.74);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-183.3834f, 16.5017f, -26.32318f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_5", 186.1572, 15.98207, 961.6981, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", 517.5204, 15.98207, 35.77629, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", 26.94058, 15.98207, -409.7199, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", -49.59304, 15.98207, 763.715, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", 163.8621, 15.98207, 92.4151, 568.3334);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", 176.811, 15.98207, 671.2859, 253.3333);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", 467.1085, 15.98207, 529.2873, 864.4445);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_f_siauliai_5", 776.9828, 15.98207, 207.4517, 900.5556);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_f_siauliai_5", -616.135, 15.98207, 64.22819, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", 278.8802, 15.98207, 664.3522, 521.25);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", 101.1124, 15.98207, 197.1371, 428.125);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", 706.5955, 15.98207, 359.2737, 560.9375);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", -25.72759, 15.98207, 14.26488, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", -325.2516, 15.98207, 8.060287, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 73.32471, 15.98207, 453.4418, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 86.27676, 15.98207, 622.724, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 582.4225, 15.98207, 420.9031, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 621.0677, 15.98207, 325.4932, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 527.5945, 15.98207, 436.7819, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 694.872, 15.98207, 281.8578, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", -49.81082, 15.98207, -73.884, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 180.974, 15.98207, 177.8814, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_5", 124.2382, 15.98207, 274.5746, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 20044, "", "ep13_f_siauliai_5", 533.5328, 15.98207, 9.088348, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 20053, "", "ep13_f_siauliai_5", 962.2645, 23.65105, -193.1123, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 147455, "", "ep13_f_siauliai_5", -459.6082, 15.98207, -45.5379, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 147455, "", "ep13_f_siauliai_5", -441.984, 15.98207, 18.71801, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 147455, "", "ep13_f_siauliai_5", -413.5721, 15.98207, 65.97212, 0);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_5_MQ03_TRACK_DLG", 2);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("I_question_arrow_mash", "TOP", 0);
				break;
			case 53:
				character.AddonMessage("NOTICE_Dm_!", "Beholder's attack is raging!{nl}Evade the trap of the demons and evacuate to a safe location!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
