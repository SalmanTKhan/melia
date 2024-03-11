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

[TrackScript("ABBAY_64_2_MQ030_TRACK")]
public class ABBAY642MQ030TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBAY_64_2_MQ030_TRACK");
		//SetMap("d_abbey_64_2");
		//CenterPos(69.05,982.54,-1256.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153110, "Edmundas", "d_abbey_64_2", -13.76, 982.53, -1335.67, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "d_abbey_64_2", 11, 982.54, -1272, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(14.89294f, 981.4951f, -1249.025f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20046, "", "d_abbey_64_2", -16.41, 982.53, -1331.77, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153120, "", "d_abbey_64_2", 7.693169, 982.5371, -1227.833, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153069, "", "d_abbey_64_2", 68.55618, 981.4951, -1273.987, 16.25);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 153069, "", "d_abbey_64_2", -77.88, 981.4951, -1404.26, 22.08333);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 153069, "", "d_abbey_64_2", 66.36962, 981.4951, -1406.617, 22.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_64_2", 68.56, 981.5, -1273.99, 22.5);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_64_2", -77.88, 981.5, -1404.26, 23.33333);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_64_2", 66.37, 981.5, -1406.62, 39.16666);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 103026, "", "d_abbey_64_2", -49.60443, 982.5371, -1151.086, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 103026, "", "d_abbey_64_2", 33.12977, 982.5371, -1146.742, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 103026, "", "d_abbey_64_2", 91.72805, 982.5371, -1154.821, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 153069, "", "d_abbey_64_2", -97.78154, 981.4951, -1253.147, 27.5);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_64_2", -97.78, 981.5, -1253.15, 31.66667);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_64_2", 8.27243, 981.4951, -1287.414, 5.454545);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "d_abbey_64_2", 42, 981.5, -1286, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 47106, "UnvisibleName", "d_abbey_64_2", -64, 981.5, -1285, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "d_abbey_64_2", -61, 981.5, -1379, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "d_abbey_64_2", 36, 981.5, -1377, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke023_red", "BOT");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 38:
				break;
			case 39:
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 1);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 41:
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_explosion014", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_explosion014", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_explosion014", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_explosion014", "BOT", 0);
				break;
			case 46:
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 58:
				await track.Dialog.Msg("ABBAY_64_2_MQ030_TRACK_DLG01");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 66:
				//DRT_ACTOR_ATTACH_EFFECT("F_light097_red", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_levitation032_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			case 68:
				CreateBattleBoxInLayer(character, track);
				break;
			case 69:
				//DRT_PLAY_MGAME("ABBAY_64_2_MQ030_MINI");
				//TRACK_SETTENDENCY();
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_darksmoke", "BOT");
				break;
			case 80:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
