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

[TrackScript("EP12_PRELUDE_04_AFTER_TRACK")]
public class EP12PRELUDE04AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_04_AFTER_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-1188.45,164.35,992.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1183.642f, 164.3527f, 994.2151f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1277, 164, 1093, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1277, 164, 893, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1077, 164, 893, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1077, 164, 1093, 0, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1424.322, 127.5562, 1698.053, 68.8);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1363.128, 127.5562, 1653.299, 64.2);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1279.407, 100.5794, 313.3007, 62.77778);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -355.8758, 268.7711, 787.627, 77.44444);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -327.5886, 246.8966, 837.9426, 80.11111);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1305.802, 100.5794, 293.2043, 62.44444);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20042, "", "f_dcapital_105", -1283.084, 164.3497, 1094.526, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20042, "", "f_dcapital_105", -1275.789, 164.3527, 891.5153, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20042, "", "f_dcapital_105", -1075.991, 164.3527, 1091.194, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20042, "", "f_dcapital_105", -1080.753, 164.3527, 893.8068, 0);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 43:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_PoleofAgony_shot_burstup", "BOT");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 70:
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "TOP");
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 87:
				character.AddonMessage("NOTICE_Dm_Clear", "[Creeping Darkness(4)]{nl}Completed!", 5);
				break;
			case 89:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
