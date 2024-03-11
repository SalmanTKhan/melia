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

[TrackScript("TABLELAND_11_1_SQ_04_TRACK")]
public class TABLELAND111SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_11_1_SQ_04_TRACK");
		//SetMap("f_tableland_11_1");
		//CenterPos(950.63,288.62,610.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(950.6323f, 288.6196f, 610.001f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156019, "", "f_tableland_11_1", 1131.15, 288.6196, 565.6184, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156020, "", "f_tableland_11_1", 1133.554, 288.6196, 465.8238, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_tableland_11_1", 1126.718, 288.6196, 551.7717, 5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57936, "", "f_tableland_11_1", 1081.65, 288.6196, 508.3063, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57936, "", "f_tableland_11_1", 1191.675, 288.6196, 495.4243, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57936, "", "f_tableland_11_1", 1142.076, 288.6196, 536.6863, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_PLAY_EFT("I_breath024_fire_purple_dark", "MID", 0);
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				break;
			case 9:
				await track.Dialog.Msg("TABLELAND_11_1_SQ_04_TRACK01");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("I_wizard_necromancer_force", "MID");
				break;
			case 26:
				await track.Dialog.Msg("TABLELAND_11_1_SQ_04_TRACK02");
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_light007_red", "MID", 0);
				break;
			case 35:
				break;
			case 40:
				await track.Dialog.Msg("TABLELAND_11_1_SQ_04_TRACK03");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark", "BOT");
				break;
			case 43:
				//TRACK_SETTENDENCY();
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_scroll", "Necromancer Faustas has called in monsters to aid him{nl}Protect Lemija from the monsters!", 5);
				//DRT_PLAY_MGAME("TABLELAND_11_1_SQ_04_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
