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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ02_TRACK")]
public class EP122DDCAPITAL108MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ02_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(478.05,24.74,-1599.45);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 453.8221, 24.74463, -1560.884, 87.85715);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150230, "Mulia", "d_dcapital_108", 454.6367, 24.74463, -1596.036, 90.71429);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 12082, "", "d_dcapital_108", 280.8137, 27.58763, -1394.221, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(480.0576f, 24.74463f, -1573.266f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 59528, "", "d_dcapital_108", -132.7505, 22.36256, -1367.433, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59528, "", "d_dcapital_108", -131.3688, 22.36256, -1329.386, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59528, "", "d_dcapital_108", -176.3428, 22.36256, -1365.555, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59528, "", "d_dcapital_108", -175.4841, 22.36256, -1332.829, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151108, "", "d_dcapital_108", -1346.889, 25.81592, 331.8279, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 153188, "", "d_dcapital_108", 2254.385, 24.74463, 332.0892, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47269, "UnvisibleName", "d_dcapital_108", 280.7942, 27.58763, -1394.057, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 483.9548, 24.74463, -1620.041, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_light166_white_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in051_yellow_loop", "BOT");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground_white", "BOT");
				break;
			case 16:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ02_TRACK_DLG_01");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_raise_levitation", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_HoleOfDarkness", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_MissileHole_explosion_violet_abil", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_barrier_shot", "BOT");
				break;
			case 48:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ02_TRACK_DLG_02");
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation022_light", "BOT");
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation022_light", "BOT");
				break;
			case 82:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ02_TRACK_DLG_03");
				break;
			case 109:
				//TRACK_SETTENDENCY();
				//DRT_ACTOR_ATTACH_EFFECT("F_sys_select_ground_red", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
