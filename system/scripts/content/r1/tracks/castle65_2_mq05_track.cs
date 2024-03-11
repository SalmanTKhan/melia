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

[TrackScript("CASTLE65_2_MQ05_TRACK")]
public class CASTLE652MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_2_MQ05_TRACK");
		//SetMap("None");
		//CenterPos(-414.03,186.67,231.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-391.6218f, 183.9413f, 207.3378f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155104, "", "None", -801.4, 187.38, 148.53, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155095, "", "None", -731.3306, 187.3789, 137.7337, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155096, "", "None", -727.7402, 187.3789, 167.0974, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155094, "", "None", -553.3461, 187.3789, 145.5154, 65);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155101, "", "None", -889.8307, 187.3789, 152.1872, 48.52941);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155113, "", "None", -411.5999, 186.6707, 243.6552, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 11282, "", "None", -755.9174, 187.3789, 104.1736, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 11282, "", "None", -769.1968, 187.3789, 199.2437, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 11283, "", "None", -811.2166, 187.3789, 97.86783, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 11283, "", "None", -849.7429, 187.3789, 178.8566, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20026, "", "None", -735.347, 187.3789, 215.9381, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20024, "", "None", -802.6288, 187.3789, 6.544126, 0);
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
			case 2:
				await track.Dialog.Msg("CASTLE652_MQ_05_track1");
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 6:
				await track.Dialog.Msg("CASTLE652_MQ_05_track2");
				break;
			case 7:
				await track.Dialog.Msg("CASTLE652_MQ_05_track3");
				break;
			case 8:
				break;
			case 18:
				await track.Dialog.Msg("CASTLE652_MQ_05_track4");
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_spread_in024_red", "MID", 1);
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in011_red_loop", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground_loop2", "BOT");
				break;
			case 35:
				await track.Dialog.Msg("CASTLE652_MQ_05_track5");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "MID", 0);
				break;
			case 42:
				await track.Dialog.Msg("CASTLE652_MQ_05_track6");
				//DRT_ACTOR_ATTACH_EFFECT("F_light080_blue_loop", "MID");
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup020_blue_mint", "BOT");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize010_blue", "BOT");
				break;
			case 61:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion069_blue", "BOT");
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_spread_out028_dark_fire", "BOT", 1);
				break;
			case 79:
				await track.Dialog.Msg("CASTLE652_MQ_05_track7");
				break;
			case 82:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 90:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 105:
				await track.Dialog.Msg("CASTLE652_MQ_05_track8");
				break;
			case 106:
				await track.Dialog.Msg("CASTLE652_MQ_05_track9");
				break;
			case 109:
				await track.Dialog.Msg("CASTLE652_MQ_05_track10");
				break;
			case 111:
				await track.Dialog.Msg("CASTLE652_MQ_05_track11");
				break;
			case 123:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 125:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
