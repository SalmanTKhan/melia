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

[TrackScript("EP13_F_SIAULIAI_3_MQ_07_TRACK")]
public class EP13FSIAULIAI3MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_MQ_07_TRACK");
		//SetMap("ep13_f_siauliai_3");
		//CenterPos(-2.27,122.49,82.61);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2.274938f, 122.4933f, 82.60852f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150243, "", "ep13_f_siauliai_3", -398.411, 84.8867, 504.522, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -277.5731, 84.8867, 712.1908, 50.625, "Qeust_Team1");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -520.7124, 84.8867, 413.2979, 135.625, "Qeust_Team2");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -491.1847, 84.8867, 347.639, 2, "Qeust_Team3");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -465.8565, 84.8867, 308.2018, 50.625, "Qeust_Team1");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -576.7042, 84.8867, 373.6732, 50.625, "Qeust_Team1");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -578.4822, 84.8867, 418.7834, 50.625, "Qeust_Team1");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -556.181, 84.8867, 753.501, 50.625, "Qeust_Team1");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -481.3679, 84.8867, 389.4418, 3, "Qeust_Team1");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -383.9325, 84.8867, 624.1993, 50.625, "Qeust_Team1");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -287.8832, 84.88671, 581.2471, 50.625, "Qeust_Team1");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -594.6401, 84.8867, 683.531, 50.625, "Qeust_Team1");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59584, "", "ep13_f_siauliai_3", -323.7477, 84.8867, 677.9596, 50.625, "Qeust_Team1");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -510.5595, 84.8867, 450.6607, 135.625, "Qeust_Team2");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -510.9922, 84.8867, 307.5315, 3.333333, "Qeust_Team2");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -372.6222, 84.8867, 673.4257, 135.625, "Qeust_Team2");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -249.9034, 84.8867, 635.4595, 135.625, "Qeust_Team2");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -304.8017, 84.8867, 618.968, 135.625, "Qeust_Team2");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -330.2053, 84.88671, 576.6534, 135.625, "Qeust_Team2");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -525.4714, 84.8867, 665.4077, 135.625, "Qeust_Team2");
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -562.1646, 84.8867, 647.2662, 135.625, "Qeust_Team2");
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 59585, "", "ep13_f_siauliai_3", -518.6901, 84.8867, 718.5133, 135.625, "Qeust_Team2");
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -555.8521, 84.8867, 340.9595, 8.125, "Qeust_Team3");
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -493.861, 84.8867, 665.0308, 8.125, "Qeust_Team3");
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -237.2283, 84.8867, 689.6296, 8.125, "Qeust_Team3");
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -313.3058, 84.8867, 539.0533, 8.125, "Qeust_Team3");
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -282.3436, 84.88671, 642.6586, 8.125, "Qeust_Team3");
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -550.999, 84.8867, 701.7495, 8.125, "Qeust_Team3");
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -570.5472, 84.8867, 612.5447, 8.125, "Qeust_Team3");
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -532.6088, 84.8867, 384.7326, 8.125, "Qeust_Team3");
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 59583, "", "ep13_f_siauliai_3", -489.7598, 84.8867, 425.3514, 8.125, "Qeust_Team3");
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -299.437, 84.8867, 700.178, 0);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		var mob32 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -285.9831, 84.88671, 626.054, 0);
		mob32.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob32.AddEffect(new ScriptInvisibleEffect());
		mob32.Layer = character.Layer;
		actors.Add(mob32);

		var mob33 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -352.203, 84.8867, 586.3712, 0);
		mob33.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob33.AddEffect(new ScriptInvisibleEffect());
		mob33.Layer = character.Layer;
		actors.Add(mob33);

		var mob34 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -529.0248, 84.8867, 692.2788, 0);
		mob34.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob34.AddEffect(new ScriptInvisibleEffect());
		mob34.Layer = character.Layer;
		actors.Add(mob34);

		var mob35 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -551.4961, 84.8867, 633.3136, 0);
		mob35.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob35.AddEffect(new ScriptInvisibleEffect());
		mob35.Layer = character.Layer;
		actors.Add(mob35);

		var mob36 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -525.0751, 84.8867, 405.4674, 0);
		mob36.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob36.AddEffect(new ScriptInvisibleEffect());
		mob36.Layer = character.Layer;
		actors.Add(mob36);

		var mob37 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -456.1408, 84.8867, 337.1624, 0);
		mob37.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob37.AddEffect(new ScriptInvisibleEffect());
		mob37.Layer = character.Layer;
		actors.Add(mob37);

		var mob38 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -574.498, 84.8867, 327.2637, 0);
		mob38.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob38.AddEffect(new ScriptInvisibleEffect());
		mob38.Layer = character.Layer;
		actors.Add(mob38);

		var mob39 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "ep13_f_siauliai_3", -394.13, 84.8867, 501.0344, 0);
		mob39.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob39.AddEffect(new ScriptInvisibleEffect());
		mob39.Layer = character.Layer;
		actors.Add(mob39);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 37:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_3_MQ_07_DLG_T1", 3);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke3", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke4", "BOT", 0);
				break;
			case 54:
				//DRT_PLAY_MGAME("EP13_F_SIAULIAI_3_MQ_07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
