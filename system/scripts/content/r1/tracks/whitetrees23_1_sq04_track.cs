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

[TrackScript("WHITETREES23_1_SQ04_TRACK")]
public class WHITETREES231SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_1_SQ04_TRACK");
		//SetMap("f_whitetrees_23_1");
		//CenterPos(-5.05,0.01,1293.50);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-12.27196f, -1.78655f, 1286.355f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_23_1", -16.06885, -10.94038, 1218.997, 47);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155142, "", "f_whitetrees_23_1", -29.23999, -11.61, 1217.73, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_23_1", -20.45, 312.75, 1208.48, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20049, "", "f_whitetrees_23_1", 58.11625, 11.3621, 1385.427, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20049, "", "f_whitetrees_23_1", 46.63222, -58.15192, 970.4166, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20049, "", "f_whitetrees_23_1", -623.8078, 10.50484, 846.5291, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20049, "", "f_whitetrees_23_1", -899.4863, 16.96842, 884.6542, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155050, "UnVisibleName", "f_whitetrees_23_1", -942.95, 11.36, 1493.16, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151028, "UnVisibleName", "f_whitetrees_23_1", -929.75, 11.36, 1461.94, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 154060, "UnVisibleName", "f_whitetrees_23_1", -1002.06, 11.36, 1447.82, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47161, "UnVisibleName", "f_whitetrees_23_1", -958.88, 11.36, 1502.41, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_PLAY_EFT("I_light013_spark", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_spread_out016_circle", "BOT", 1);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_archer_JumpShot_hit1", "BOT", 1);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_hit_poison_hit_green", "BOT", 1);
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "TOP");
				break;
			case 22:
				break;
			case 30:
				await track.Dialog.Msg("WHITETREES231_SQ_04_track1");
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_light094_blue", "BOT", 1);
				break;
			case 40:
				await track.Dialog.Msg("WHITETREES231_SQ_04_track2");
				break;
			case 51:
				await track.Dialog.Msg("WHITETREES231_SQ_04_track3");
				break;
			case 54:
				break;
			case 55:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//DRT_PLAY_MGAME("WHITETREES23_1_SQ04_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
