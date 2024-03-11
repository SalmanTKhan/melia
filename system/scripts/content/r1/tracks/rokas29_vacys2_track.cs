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

[TrackScript("ROKAS29_VACYS2_TRACK")]
public class ROKAS29VACYS2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS29_VACYS2_TRACK");
		//SetMap("f_rokas_29");
		//CenterPos(1691.26,470.82,429.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152000, "바키스", "f_rokas_29", 1365.747, 470.8202, 638.1687, 20);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57504, "", "f_rokas_29", 1255.483, 470.8202, 607.4839, 85.89286);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1691.257f, 470.8201f, 429.0816f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_rokas_29", 1282.589, 470.8202, 583.9269, 6.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "f_rokas_29", 1384.346, 470.8201, 596.2271, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "f_rokas_29", 1438.459, 470.8704, 595.365, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20025, "", "f_rokas_29", 1488.256, 471.1056, 595.1948, 25);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "f_rokas_29", 1175.443, 470.8202, 329.7209, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation017_smoke", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation017_smoke", "MID");
				break;
			case 14:
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize010_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize004_dark", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion100_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize010_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize004_dark", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion100_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize010_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize004_dark", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion100_blue", "BOT");
				break;
			case 44:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-180);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
