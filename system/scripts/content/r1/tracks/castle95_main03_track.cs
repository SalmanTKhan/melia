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

[TrackScript("CASTLE95_MAIN03_TRACK")]
public class CASTLE95MAIN03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE95_MAIN03_TRACK");
		//SetMap("f_castle_95");
		//CenterPos(913.63,34.27,-536.50);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(911f, 34.37f, -537f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147414, "", "f_castle_95", 858, 32, -733, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151067, "", "f_castle_95", 800, 32, -788, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151067, "", "f_castle_95", 908, 32, -679, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151067, "", "f_castle_95", 904, 32, -788, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151067, "", "f_castle_95", 804, 32, -676, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147501, "", "f_castle_95", 858, 32, -733, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 904, 32, -788, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 908, 32, -679, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 804, 32, -676, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 800, 32, -788, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 17:
				character.AddonMessage("NOTICE_Dm_Clear", "The obelisk has been demolished!", 4);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_turret_hit_explosion", "BOT", 0);
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
