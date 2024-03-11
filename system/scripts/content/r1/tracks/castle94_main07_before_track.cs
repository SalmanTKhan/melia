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

[TrackScript("CASTLE94_MAIN07_BEFORE_TRACK")]
public class CASTLE94MAIN07BEFORETRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE94_MAIN07_BEFORE_TRACK");
		//SetMap("f_castle_94");
		//CenterPos(565.65,289.92,2870.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(566.634f, 289.9216f, 2868.718f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152023, "", "f_castle_94", 575, 289, 2887, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 321.481, 289.9216, 2858.172, 40);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 339.0725, 289.9216, 2741.558, 185);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 382.1576, 289.9216, 2677.979, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 458.4431, 289.9216, 2627.832, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 551.791, 289.9216, 2619.894, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 321.48, 289.92, 2858.17, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 339.07, 289.92, 2741.56, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 382.16, 289.92, 2677.98, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 458.44, 289.92, 2627.83, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 551.79, 289.92, 2619.89, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 154067, "", "f_castle_94", 575, 289, 2887, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_Foretell_ground_magic", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_item_drop_line_loop_unknown", "BOT");
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_light059_event", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark_loop", "BOT");
				break;
			case 26:
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 32:
				break;
			case 48:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				break;
			case 49:
				//DRT_PLAY_MGAME("CASTLE94_MAIN07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
