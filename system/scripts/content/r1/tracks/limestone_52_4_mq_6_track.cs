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

[TrackScript("LIMESTONE_52_4_MQ_6_TRACK")]
public class LIMESTONE524MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_4_MQ_6_TRACK");
		//SetMap("d_limestonecave_52_4");
		//CenterPos(1457.10,-14.33,-663.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1457.097f, -14.33093f, -663.5089f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_4", 1492.663, -22.1069, -624.1932, 103.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_limestonecave_52_4", 1198.525, -18.66856, -1259.509, 39.16666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_4", 1539.394, -18.66856, -771.2944, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1223.677, -18.66856, -1251.597, 71);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1225.051, -18.66856, -1253.225, 79);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1224.091, -18.66856, -1251.182, 55);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1226.083, -18.66856, -1252.193, 76);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1224.845, -18.66856, -1253.431, 75);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58473, "", "d_limestonecave_52_4", 1223.055, -18.66856, -1252.218, 54);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1530.977, -18.66856, -783.9366, 92);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1530.177, -18.66856, -785.4367, 98);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1530.681, -18.66856, -787.0281, 70);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 58472, "", "d_limestonecave_52_4", 1531.07, -18.66856, -784.5439, 100);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 16:
				break;
			case 21:
				character.AddonMessage("NOTICE_Dm_!", "The demon portal has opened!", 6);
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 23:
				break;
			case 27:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 28:
				//TRACK_SETTENDENCY();
				break;
			case 29:
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
