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

[TrackScript("MINE_3_BOSS_TRACK")]
public class MINE3BOSSTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MINE_3_BOSS_TRACK");
		//SetMap("d_cmine_6");
		//CenterPos(2081.84,56.93,1745.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2114.755f, 56.9321f, 1761.942f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47233, "UnvisibleName", "d_cmine_6", 2048.03, 56.93, 1753.45, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 2097.899, 56.9321, 1657.5, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1734.283, 56.9321, 1671.702, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1739.799, 56.9321, 1638.14, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1740.752, 56.9321, 1624.371, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1777.005, 56.9321, 1523.793, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1773.169, 56.9321, 1515.773, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1756.102, 56.9321, 1500.333, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1741.385, 56.9321, 1503.693, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1716.906, 56.9321, 1512.873, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1697.229, 56.9321, 1504.72, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1663.956, 56.9321, 1614.941, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1763.386, 56.9321, 1593.279, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1652.421, 57.39038, 1634.544, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1599.698, 104.2843, 1662.457, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1615.515, 77.26265, 1636.446, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1570.745, 127.3815, 1703.672, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 1690.96, 56.9321, 1461.93, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 1614.104, 85.12413, 1646.18, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2125.824, 56.9321, 1623.808, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2196.028, 56.9321, 1623.566, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2156.026, 56.9321, 1620.849, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2138.417, 56.9321, 1581.684, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2143.343, 56.9321, 1673.27, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2173.722, 56.9321, 1664.632, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 57801, "UnvisibleName", "d_cmine_6", 2137.947, 56.9321, 1633.805, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 2086.342, 56.9321, 1663.564, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 2099.437, 56.9321, 1686.483, 0);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 2160.783, 56.9321, 1689.001, 0.8510638);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 400401, "", "d_cmine_6", 2156.067, 56.9321, 1675.913, 0);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_cmine_6", 2150.636, 56.9321, 1681.211, 0);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle019", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_OOBE_shot_explosion", "BOT");
				break;
			case 9:
				break;
			case 10:
				break;
			case 21:
				break;
			case 23:
				break;
			case 24:
				break;
			case 25:
				break;
			case 26:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_bat001", "MID");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_bat001", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke132_dash", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_bat001", "BOT");
				break;
			case 35:
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("I_bat001", "MID");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("I_bat002", "TOP");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_violet", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "MID");
				break;
			case 43:
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "TOP");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("bat_event_drop", "TOP");
				break;
			case 64:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
