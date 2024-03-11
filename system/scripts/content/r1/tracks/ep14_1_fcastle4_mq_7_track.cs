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

[TrackScript("EP14_1_FCASTLE4_MQ_7_TRACK")]
public class EP141FCASTLE4MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_7_TRACK");
		//SetMap("ep14_1_f_castle_4");
		//CenterPos(346.14,-29.20,1129.14);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 161025, "", "ep14_1_f_castle_4", 257.8699, -29.19576, 1142.097, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(346.1396f, -29.19576f, 1129.136f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 155172, "", "ep14_1_f_castle_4", 254.327, -29.19576, 1144.31, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151021, "", "ep14_1_f_castle_4", 348.9936, -29.19576, 1127.201, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151021, "", "ep14_1_f_castle_4", 250.2786, -29.19576, 1146.632, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_4", 263.3065, -29.19576, 1189.638, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_4", 254.762, -29.19576, 1089.932, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_4", 205.114, -29.19576, 1144.785, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 263.9057, -29.19576, 1185.672, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59704, "", "ep14_1_f_castle_4", 206.6854, -29.19576, 1144.327, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 256.346, -29.19576, 1090.489, 0);
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
			case 6:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force099_2", "skl_eff_forecast_shot", "F_smoke005_dark", "skl_eff_explosion", "FAST", 200, 0, 0, 0, 10, 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke023_dark", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("I_smoke023_dark", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("I_smoke023_dark", "BOT", 0);
				break;
			case 13:
				//DRT_JUMP_TO_POS(0.2, 50);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_explosion128_dark2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke183_smoke_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke183_smoke_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke183_smoke_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "BOT", 0);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
