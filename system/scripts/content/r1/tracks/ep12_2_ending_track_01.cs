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

[TrackScript("EP12_2_ENDING_TRACK_01")]
public class EP122ENDINGTRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_01");
		//SetMap("d_dcapital_108");
		//CenterPos(470.84,23.86,1836.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(470.84f, 23.85547f, 1836.35f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154040, "", "d_dcapital_108", 344.608, 23.85547, 2276.597, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153092, "", "d_dcapital_108", 473.5028, 23.85547, 2275.999, 0.8196722);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.1133, 23.85547, 2184.137, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "d_dcapital_108", 474.3736, 23.85547, 2057.263, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154040, "", "d_dcapital_108", 474.9213, 23.85547, 2056.721, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47269, "UnvisibleName", "d_dcapital_108", 470.0118, 23.85547, 1840.703, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 153092, "", "d_dcapital_108", 471.5966, 23.85547, 1898.6, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 153092, "", "d_dcapital_108", 473.792, 23.85547, 2275.606, 0);
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
			case 23:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_1");
				break;
			case 24:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_2");
				break;
			case 25:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_3");
				break;
			case 27:
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("I_force071_dark4", "MID");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "MID", 0);
				break;
			case 44:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force071_dark4", "skl_eff_dark", "F_explosion026_rize_red2", "arrow_blow", "FAST", 200, 1, 0, 5, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_burstup006_dark", "BOT", 0);
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("I_thornbush001_mesh", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 59:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_11");
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("I_bomb006_dark", "MID", 0);
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_dark", "TOP", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_explosion125_red", "BOT", 0);
				break;
			case 77:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ16_DLG_4");
				break;
			case 88:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ16_DLG_12", 10);
				break;
			case 89:
				//DRT_PLAY_MGAME("EP12_2_ENDING_MINI_01");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
