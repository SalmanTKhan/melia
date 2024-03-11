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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ14")]
public class EP122DDCAPITAL108MQ14 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ14");
		//SetMap("d_dcapital_108");
		//CenterPos(2296.15,24.74,481.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2292.05f, 24.74463f, 501.6277f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150230, "", "d_dcapital_108", 2256.904, 24.74463, 497.7352, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 2273.169, 24.74463, 500.7363, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153188, "", "d_dcapital_108", 2252.859, 24.74463, 333.1343, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 2239.329, 24.74463, 315.0488, 12.27273);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 2276.211, 24.74463, 317.3734, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 2269.418, 24.74463, 348.2252, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 2232.756, 24.74463, 348.9771, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2082.65, 24.74463, 118.1485, 49.78261);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2102.539, 22.83998, 83.05206, 61.52174);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2088.348, 22.83998, 54.75447, 60.21739);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2121.66, 23.71011, 100.7655, 54.56522);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2085.421, 22.83998, 17.17484, 70.21739);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2125.229, 22.83998, 2.035759, 82.6087);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2087.427, 22.83998, -19.27834, 88.91305);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2130.596, 22.83998, -23.15643, 90.86957);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2087.162, 22.83998, -51.75061, 103.6957);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 400001, "", "d_dcapital_108", 2113.991, 22.83998, -48.36306, 98.26087);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 26:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ14_TRACK_DLG_01");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_burstup004_dark2", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark2", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern008_explosion_mash_square", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern008_explosion_mash_square", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern008_explosion_mash_square", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern008_explosion_mash_square", "BOT");
				break;
			case 55:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ14_TRACK_DLG_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
