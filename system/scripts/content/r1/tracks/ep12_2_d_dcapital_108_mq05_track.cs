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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ05_TRACK")]
public class EP122DDCAPITAL108MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ05_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(-1347.24,25.82,406.67);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151108, "", "d_dcapital_108", -1348.662, 25.81592, 334.2339, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "Mulia", "d_dcapital_108", -1326.872, 25.81592, 360.6171, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", -1354.905, 25.81592, 369.4252, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-1347.238f, 25.81592f, 406.6697f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1420.678, 25.81592, 335.1873, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1388.854, 25.81592, 262.321, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1297.712, 25.81592, 263.8097, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1269.273, 25.81592, 335.471, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1394.838, 25.81592, 406.2249, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147504, "UnvisibleName", "d_dcapital_108", -1296.141, 25.81592, 398.4924, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_SETPOS();
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_red", "BOT");
				break;
			case 15:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup020_blue_mint", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark2", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire018_purple", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder005_light_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light110_pink_ground_blood", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood006_red", "BOT");
				break;
			case 43:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ05_TRACK_DLG_01");
				break;
			case 44:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ05_TRACK_DLG_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
