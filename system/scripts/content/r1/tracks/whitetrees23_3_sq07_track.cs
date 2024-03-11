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

[TrackScript("WHITETREES23_3_SQ07_TRACK")]
public class WHITETREES233SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_3_SQ07_TRACK");
		//SetMap("None");
		//CenterPos(27.76,160.13,519.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(100.531f, 165.0884f, 529.5338f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47253, "", "None", 76.78, 165.09, 531.55, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155148, "", "None", 76.78, 165.09, 531.55, 3.333333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47107, "", "None", 40.55, 165.09, 666.78, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47107, "", "None", 113.01, 165.09, 666.78, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47107, "", "None", 175.77, 165.09, 630.54, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47107, "", "None", 212.01, 165.09, 567.78, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47107, "", "None", 212.01, 165.09, 495.32, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47107, "", "None", 175.77, 165.09, 432.56, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47107, "", "None", 113.01, 165.09, 396.32, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47107, "", "None", 40.55, 165.09, 396.32, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47107, "", "None", -22.21, 165.09, 432.56, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47107, "", "None", -58.45, 165.09, 495.32, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47107, "", "None", -58.45, 165.09, 567.78, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 47107, "", "None", -22.21, 165.09, 630.54, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20026, "", "None", 122.3541, 165.0884, 487.835, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20026, "", "None", 135.5825, 165.0884, 546.6838, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 20026, "", "None", 57.9365, 165.0884, 606.3634, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20026, "", "None", 4.747673, 165.0884, 547.9995, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 20026, "", "None", 60.87659, 165.0884, 475.3502, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_lineup020_blue_mint", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("E_ground001_light", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 30:
				//DRT_RUN_FUNCTION("SCR_WHITETREES233_SQ_07_CHAT1");
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("None", "BOT", 1);
				break;
			case 40:
				//DRT_RUN_FUNCTION("SCR_WHITETREES233_SQ_07_CHAT2");
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 44:
				await track.Dialog.Msg("WHITETREES233_SQ_07_track1");
				//DRT_ACTOR_PLAY_EFT("F_smoke074", "BOT", 1);
				break;
			case 45:
				CreateBattleBoxInLayer(character, track);
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
