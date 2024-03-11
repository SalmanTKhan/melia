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

[TrackScript("DCAPITAL53_1_MQ_02_TRACK")]
public class DCAPITAL531MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL53_1_MQ_02_TRACK");
		//SetMap("f_desolated_capital_53_1");
		//CenterPos(2103.14,111.87,2373.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2226.267f, 111.8744f, 2379.638f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 40120, "", "f_desolated_capital_53_1", 1515.549, 111.8744, 2274.188, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59328, "", "f_desolated_capital_53_1", 1791.922, 111.8744, 2749.402, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59327, "", "f_desolated_capital_53_1", 1731.019, 111.8744, 2603.893, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59327, "", "f_desolated_capital_53_1", 1796.274, 111.8744, 2592.615, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59356, "", "f_desolated_capital_53_1", 1724.246, 111.8744, 2653.686, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59356, "", "f_desolated_capital_53_1", 1803.128, 111.8744, 2646.452, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57191, "", "f_desolated_capital_53_1", 1617.194, 110.4872, 1948.605, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57191, "", "f_desolated_capital_53_1", 1259.073, 127.4073, 2045.555, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 156129, "", "f_desolated_capital_53_1", 1289.05, 116.1947, 2089.812, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 11283, "", "f_desolated_capital_53_1", 1220.776, 117.119, 2006.312, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20012, "", "f_desolated_capital_53_1", 1615.245, 101.5809, 1889.078, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 156117, "", "f_desolated_capital_53_1", 1591.173, 111.8744, 1974.84, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59327, "", "f_desolated_capital_53_1", 1183.829, 110.312, 2002.366, 0.4);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59327, "", "f_desolated_capital_53_1", 1132.263, 110.312, 1910.316, 17.94118);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59326, "", "f_desolated_capital_53_1", 1613.09, 53.67372, 1723.821, 10);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59326, "", "f_desolated_capital_53_1", 1595.058, 88.10066, 1847.823, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2066.782, 111.874, 2250.89, 0, "Our_Forces");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2105.11, 111.874, 2432.84, 0, "Our_Forces");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2085.82, 111.874, 2335.28, 0, "Our_Forces");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 150221, "", "f_desolated_capital_53_1", 2060.531, 111.874, 2386.672, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 150219, "", "f_desolated_capital_53_1", 2045.183, 111.874, 2299.125, 0, "Our_Forces");
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 59356, "", "f_desolated_capital_53_1", 2175.265, 111.8744, 2384.627, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 59327, "", "f_desolated_capital_53_1", 2078.609, 111.8744, 2290.946, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 20042, "", "f_desolated_capital_53_1", 1829.854, 111.8744, 2506.364, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_ground_incenseburner", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_ground_incenseburner", "BOT");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_red", "MID", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_hit_good_blue", "MID", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 66:
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_hit_good_blue", "MID", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_hit017_2", "MID", 0);
				break;
			case 109:
				//DRT_ACTOR_PLAY_EFT("F_explosion111_smoke", "BOT", 0);
				break;
			case 121:
				character.AddonMessage("NOTICE_Dm_scroll", "Fight off the orcs rushing in to destroy the Goddess Statue!", 5);
				break;
			case 124:
				//DRT_PLAY_MGAME("DCAPITAL53_1_MQ_02_MINI");
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
