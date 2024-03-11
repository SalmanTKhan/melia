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

[TrackScript("F_MAPLE_24_2_MQ_09_TRACK")]
public class FMAPLE242MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_09_TRACK");
		//SetMap("f_maple_24_2");
		//CenterPos(-1267.04,8.77,698.04);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_2", -1285.848, 8.768949, 687.5028, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1274.959f, 8.768949f, 704.0974f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 156159, "Kartas", "f_maple_24_2", -1014.934, 8.768948, 679.3188, 26.38889);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1122.758, 8.768949, 602.6383, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57578, "", "f_maple_24_2", -1285.376, 1.2381, 633.3277, 20.625);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57579, "", "f_maple_24_2", -1277.599, 8.768948, 729.7283, 26);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -998.4341, 8.768948, 801.5289, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1061.364, 8.76895, 559.4785, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -965.4707, 8.768945, 747.4797, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -983.9625, 8.76895, 634.036, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_2", -1354.229, 11.09299, -541.257, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1352.43, 11.09299, -548.364, 16.52174);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_2", -1229.855, 8.76895, 703.0779, 2.096774);
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
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_01");
				break;
			case 11:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_02");
				break;
			case 23:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_03");
				break;
			case 27:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_04");
				break;
			case 30:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_05");
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				//DRT_PLAY_FORCE(0, 0, 2, "I_force096_dark", "arrow_cast", "F_explosion035_pink", "arrow_blow", "SLOW", 100, 1, 0, 10, 10, 0);
				break;
			case 49:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_06");
				break;
			case 53:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_07");
				break;
			case 54:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_08");
				break;
			case 55:
				await track.Dialog.Msg("F_MAPLE_242_TRACK2_09");
				break;
			case 70:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground023", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground023", "BOT");
				break;
			case 72:
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_2", "TOP");
				break;
			case 88:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_leaf", "MID", 0);
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue3", "TOP", 0);
				break;
			case 97:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
