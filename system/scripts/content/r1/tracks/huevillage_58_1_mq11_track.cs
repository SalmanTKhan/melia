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

[TrackScript("HUEVILLAGE_58_1_MQ11_TRACK")]
public class HUEVILLAGE581MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_1_MQ11_TRACK");
		//SetMap("f_huevillage_58_1");
		//CenterPos(-891.73,230.98,208.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147407, "", "f_huevillage_58_1", -1052.554, 230.9787, 434.3509, 23.33333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147408, "", "f_huevillage_58_1", -1017.822, 230.9787, 505.1138, 20);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147409, "", "f_huevillage_58_1", -1059.846, 230.9787, 470.2299, 21.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147408, "", "f_huevillage_58_1", -1022.848, 230.9787, 440.2231, 10);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147420, "", "f_huevillage_58_1", -1053.287, 230.9787, 497.2288, 7.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147419, "", "f_huevillage_58_1", -1086.391, 230.9787, 425.0972, 18);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47236, "", "f_huevillage_58_1", -1017.879, 230.9787, 473.5001, 7.857143);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47124, "", "f_huevillage_58_1", -1250, 230, 490, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		character.Movement.MoveTo(new Position(-932.0406f, 230.9787f, 214.6864f));
		actors.Add(character);

		var mob8 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1050.788, 230.9787, 429.5533, 18.15789);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1016.781, 230.9787, 499.0615, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1059.85, 230.98, 470.23, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1081.529, 230.9787, 421.3697, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1053.29, 230.98, 497.23, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 400102, "", "f_huevillage_58_1", -1022.85, 230.98, 440.22, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood009_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke064_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 35:
				//DRT_FUNC_ACT("HUEVILLAGE_58_1_TO_HUEVILLAGE_58_4_PORTAL");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic032_yellow_line", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_yellow", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
