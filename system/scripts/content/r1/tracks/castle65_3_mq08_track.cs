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

[TrackScript("CASTLE65_3_MQ08_TRACK")]
public class CASTLE653MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_3_MQ08_TRACK");
		//SetMap("f_castle_65_2");
		//CenterPos(145.39,67.02,-269.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1144.539f, 0.03453375f, -1619.335f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155101, "", "f_castle_65_2", 1603.007, 75.57725, -709.1643, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151001, "UnVisibleName", "f_castle_65_2", 1597.822, 75.57725, -721.7242, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58039, "", "f_castle_65_2", 1604.707, 75.57725, -716.6748, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "f_castle_65_2", 1603.01, 75.58, -709.16, 0.212766);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155094, "", "f_castle_65_2", 1163.1, 0.75, -1572.72, 31.66667);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147379, "UnVisibleName", "f_castle_65_2", 1197.16, 2.61, -1555.22, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "f_castle_65_2", 1241.931, 14.0984, -1552.536, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "f_castle_65_2", 1603.01, 75.58, -709.16, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_explosion049_fire", "MID", 1);
				break;
			case 20:
				await track.Dialog.Msg("CASTLE653_MQ_08_track1");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 42:
				await track.Dialog.Msg("CASTLE653_MQ_08_track2");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_light047_red", "MID", 1);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_red", "BOT");
				break;
			case 53:
				await track.Dialog.Msg("CASTLE653_MQ_08_track3");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "MID");
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark_loop", "MID");
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("I_force015_white", "MID", 1);
				break;
			case 75:
				//DRT_ACTOR_PLAY_EFT("F_levitation032_red_loop", "MID", 1);
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in013_smoke", "BOT");
				break;
			case 77:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke041_red", "BOT");
				break;
			case 84:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 1);
				break;
			case 91:
				//DRT_ACTOR_ATTACH_EFFECT("I_spell_crystal_gem_red_parts_mash", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion032_red", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke043_orange", "BOT");
				break;
			case 92:
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_smoke042_red", "BOT", 1);
				break;
			case 98:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "MID");
				break;
			case 108:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out028_dark_fire", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			case 115:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
