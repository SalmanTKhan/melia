using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP12_FINALE_02_TRACK")]
public class EP12FINALE02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_FINALE_02_TRACK");
		//SetMap("f_dcapital_104");
		//CenterPos(330.50,-27.39,-105.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(330.4953f, -27.38526f, -105.1473f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153092, "", "f_dcapital_104", 222.5412, 2.09552, 220.1388, 5.142857);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153091, "", "f_dcapital_104", 223.0392, 2.09552, 271.3672, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 186.6985, 2.09552, 207.8038, 65);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 190.8287, 2.09552, 197.5749, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 196.4238, 2.09552, 189.4984, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 204.5763, 2.09552, 183.4705, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 213.142, 2.09552, 180.1605, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 222.6193, 2.09552, 178.2273, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 231.4273, 2.09552, 179.407, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 240.0898, 2.09552, 182.3426, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 247.8281, 2.09552, 187.6913, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 253.1795, 2.09552, 194.7085, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47234, "", "f_dcapital_104", 256.5075, 2.09552, 203.3742, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20041, "", "f_dcapital_104", 214.8038, 2.09552, 155.9747, 0);
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
			case 2:
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 34:
				await track.Dialog.Msg("EP12_FINALE_02_DLG01");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_ground083_smoke_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 43:
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke027_dark_loop2", "BOT");
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet", "BOT", 0);
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke061_dark_violet_levitation_loop", "BOT");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2", "BOT");
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 86:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 94:
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowCondensation_dark", "BOT", 0);
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("F_archer_TripleArrow_hit_explosion", "BOT", 0);
				break;
			case 104:
				break;
			case 118:
				//DRT_RUN_FUNCTION("SCR_EP12_FINALE_02_TRACK_DAYLIGHT_SET");
				break;
			case 127:
				await track.Dialog.Msg("EP12_FINALE_02_DLG02");
				break;
			case 131:
				await track.Dialog.Msg("EP12_FINALE_02_DLG03");
				break;
			case 134:
				await track.Dialog.Msg("EP12_FINALE_02_DLG04");
				break;
			case 136:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				break;
			case 137:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke041_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in025_red", "BOT", 0);
				break;
			case 147:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
