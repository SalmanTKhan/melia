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

[TrackScript("DCAPITAL105_SQ_6_TRACK")]
public class DCAPITAL105SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL105_SQ_6_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-169.67,294.51,1524.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154012, "", "f_dcapital_105", -141.8394, 294.5138, 1661.762, 50);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(54.34097f, 296.3268f, 1290.741f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -241.0653, 294.514, 1463.904, 79.28571);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -248.0171, 294.5135, 1705.297, 51.42857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -238.0019, 294.5139, 1576.291, 61.78572);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -245.4116, 294.5137, 1642.426, 56.42857);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -221.6421, 294.5136, 1743.076, 44.64286);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -130.9665, 294.5137, 1778.071, 26.07143);
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
			case 7:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "F_hit011_puple_light", "arrow_blow", "SLOW", 150, 1, 0, 5, 10, 0);
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				break;
			case 19:
				character.AddonMessage("NOTICE_Dm_!", "Please, defeat the demon chasers and rescue Kupole Zsaia!", 8);
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
