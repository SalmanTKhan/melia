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

[TrackScript("EP12_2_ENDING_TRACK_02_AFTER")]
public class EP122ENDINGTRACK02AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_02_AFTER");
		//SetMap("d_dcapital_108");
		//CenterPos(470.80,23.86,2242.14);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(470.9799f, 23.85547f, 2242.323f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150241, "", "d_dcapital_108", 473.3766, 23.85547, 2370.88, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47269, "", "d_dcapital_108", 470.2906, 23.85547, 1840.685, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154040, "", "d_dcapital_108", 472.208, 23.85547, 1842.812, 14.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 485.0325, 23.85547, 1821.278, 12.83333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150240, "", "d_dcapital_108", 456.221, 23.85547, 1829.979, 14.16667);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 463.6662, 23.85547, 2243.005, 0.2941177);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 475.7372, 23.85547, 2229.333, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 470.9027, 23.85547, 2220.641, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 478.2714, 23.85547, 2210.698, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 470.0047, 23.85547, 2200.838, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150215, "", "d_dcapital_108", 473.6626, 23.85547, 2151.396, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.448, 23.85547, 2202.091, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.2069, 23.85547, 2202.303, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.9294, 23.85547, 2201.668, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.8521, 23.85547, 2202.043, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_burstup029_smoke_dark2", "BOT", 0);
				break;
			case 9:
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "TOP", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "TOP", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_explosion101_dark", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion096_dark", "MID", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_explosion026_rize_red1", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize006_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_holy_loop", "BOT");
				break;
			case 52:
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in002_orange2", "MID", 0);
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop2", "MID");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash029_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_explosion004_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_yellow2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_light013_spark_yellow", "MID", 0);
				break;
			case 61:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 62:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 63:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 79:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 80:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 83:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 84:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 85:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 87:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 88:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 89:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 91:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 95:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 96:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force079_yellow", "skl_eff_twistoffate_force", "F_explosion035_yellow1", "None", "FAST", 150, 1, 0, 1, 1, 0);
				break;
			case 102:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow2", "BOT");
				break;
			case 116:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_8");
				break;
			case 117:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ17_DLG_9");
				break;
			case 134:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ17_DLG_6", 10);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
