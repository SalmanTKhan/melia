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

[TrackScript("ROKAS29_MQ3_TRACK")]
public class ROKAS29MQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS29_MQ3_TRACK");
		//SetMap("f_rokas_29");
		//CenterPos(-186.40,681.29,498.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47106, "Epitaph", "f_rokas_29", -206, 681, 495, 1);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47413, "Rexipher", "f_rokas_29", 57.99627, 681.7787, 594.8981, 34.21053);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 401301, "", "f_rokas_29", -334.1107, 681.291, 598.0709, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 401301, "", "f_rokas_29", -203.5434, 681.2914, 648.566, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 401301, "", "f_rokas_29", -292.0146, 681.2906, 500.8454, 43.125);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 401301, "", "f_rokas_29", -128.6894, 681.2914, 601.0721, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 401301, "", "f_rokas_29", -107.6839, 681.5992, 477.394, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-187.3152f, 681.2907f, 495.9131f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red##2", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_reward_shot_lineup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				//ChangeScale(1.5, 0);
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic029_red_line", "BOT");
				break;
			case 15:
				//ChangeScale(1.7, 0);
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic029_red_line", "BOT");
				//ChangeScale(0.5, 0);
				break;
			case 19:
				//DRT_MOVETOTGT(50);
				//ChangeScale(1.3, 0);
				break;
			case 22:
				break;
			case 23:
				//DRT_MOVETOTGT(50);
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ShapeShifting_ground", "BOT");
				break;
			case 26:
				//DRT_MOVETOTGT(50);
				break;
			case 28:
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				break;
			case 33:
				//DRT_PLAY_MGAME("ROKAS29_MQ3_MINI");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
