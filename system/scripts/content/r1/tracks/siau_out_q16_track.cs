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

[TrackScript("SIAU_OUT_Q16_TRACK")]
public class SIAUOUTQ16TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU_OUT_Q16_TRACK");
		//SetMap("f_siauliai_out");
		//CenterPos(-70.71,148.35,-687.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-63.31387f, 145.2419f, -798.0307f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 45315, "", "f_siauliai_out", -82, 156, -612, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 45315, "", "f_siauliai_out", -41.53503, 157.8847, -606.0453, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 45315, "", "f_siauliai_out", -54.27855, 159.1952, -580.191, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 106000, "", "f_siauliai_out", -122.3407, 153.713, -255.4688, 22.71428);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 106000, "", "f_siauliai_out", -62.51195, 153.713, -255.0102, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 106000, "", "f_siauliai_out", -33.49472, 153.713, -307.0574, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40120, "", "f_siauliai_out", 228, 42, -1210, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40070, "2광구", "f_siauliai_out", 129, 153, -18, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40070, "Notice", "f_siauliai_out", -125, 153, -443, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//CREATE_BATTLE_BOX_INLAYER(-200);
				break;
			case 5:
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001", "MID");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001", "MID");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001", "MID");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion050_fire", "MID");
				break;
			case 42:
				break;
			case 67:
				//DRT_PLAY_MGAME("SIAU_OUT_Q16_TRACK");
				break;
			case 79:
				//TRACK_SETTENDENCY();
				break;
			case 80:
				break;
			case 86:
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
