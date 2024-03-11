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

[TrackScript("LIMESTONE_52_3_MQ_9_TRACK")]
public class LIMESTONE523MQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_3_MQ_9_TRACK");
		//SetMap("d_limestonecave_52_3");
		//CenterPos(323.14,124.72,-1427.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(323.1432f, 124.7248f, -1427.251f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_3", 704.3815, 124.7245, -1445.42, 2.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58069, "", "d_limestonecave_52_3", 631.4518, 124.7245, -1460.787, 10.83333, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57311, "", "d_limestonecave_52_3", 689.4539, 124.7246, -1329.771, 60, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58037, "", "d_limestonecave_52_3", 652.1046, 124.7245, -1387.256, 27.5, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58451, "", "d_limestonecave_52_3", 475.8247, 124.7245, -1408.341, 25);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_3", 472.74, 124.7245, -1331.62, 73);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_3", 538.4931, 124.7245, -1555.695, 5.952381);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_3", 328.6711, 124.7251, -1411.433, 51.25);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 700.0048, 124.7245, -1438.942, 12.10526);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 451.3405, 124.7245, -1415.402, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 632.0439, 124.7245, -1462.411, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 645.174, 124.7245, -1378.298, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 707.4797, 124.7245, -1350.671, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 411.6646, 124.7246, -1386.838, 772.5);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 705.4335, 124.7245, -1470.196, 0);
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
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic003_red", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_stone_event_parts2_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke018_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup022_smoke_s", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke037_1", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in014_circle", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_summon_ground_violet", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet", "BOT");
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin003_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin003_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin003_violet", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion105_blood", "BOT");
				break;
			case 47:
				//InsertHate(999);
				break;
			case 48:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 50:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_event", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 51:
				character.AddonMessage("NOTICE_Dm_scroll", "The demons have kidnapped Goddess Dalia!", 6);
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light027_violet", "BOT");
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground086_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic003_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic003_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 61:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the Starlakhan that has fallen in line with the demons!", 6);
				break;
			case 64:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
