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

[TrackScript("WHITETREES23_1_SQ02_TRACK")]
public class WHITETREES231SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_1_SQ02_TRACK");
		//SetMap("None");
		//CenterPos(701.85,12.65,1274.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(672.024f, 11.3621f, 1289.293f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155150, "", "None", 678.4797, 11.3621, 1277.521, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155151, "", "None", 394.8387, 11.3621, 1567.593, 30);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155151, "", "None", 306.3396, 11.3621, 1566.713, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155151, "", "None", 64.74166, 11.3621, 1380.385, 27.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58546, "", "None", 218.1758, 11.3621, 1420.045, 37);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58546, "", "None", 240.1624, 11.3621, 1283.867, 89);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58546, "", "None", 373.0813, 11.3621, 1451.111, 20.27778);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58546, "", "None", 428.6402, 11.3621, 1345.975, 63.88889);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58546, "", "None", 494.0962, 11.3621, 1208.839, 22.77778);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20049, "", "None", 673.4592, 11.3621, 1291.408, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20049, "", "None", 336.869, 11.3621, 1572.876, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20049, "", "None", 57.60714, 11.3621, 1386.029, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "None", 690.4402, 11.3621, 1294.659, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20025, "", "None", 383.6634, 11.3621, 1505.586, 39.16666);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20025, "", "None", 67.35624, 11.3621, 1375.763, 0);
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
			case 11:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("F_archer_entangle_shot_smoke", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_shot_smoke", "BOT");
				break;
			case 19:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_shot_smoke", "BOT");
				break;
			case 28:
				break;
			case 35:
				character.AddonMessage("NOTICE_Dm_!", "The monsters in the trap have begun to act violently!", 3);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				break;
			case 39:
				break;
			case 40:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
