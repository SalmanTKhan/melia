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

[TrackScript("ORCHARD_324_MQ_06_TRACK")]
public class ORCHARD324MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_324_MQ_06_TRACK");
		//SetMap("f_orchard_32_4");
		//CenterPos(-1523.71,612.29,902.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1458.944f, 612.3004f, 903.61f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155104, "UnvisibleName", "f_orchard_32_4", -1704.186, 612.3004, 887.5585, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147382, "", "f_orchard_32_4", -1739.065, 612.3004, 887.1659, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58087, "", "f_orchard_32_4", -1812.611, 612.3004, 887.6365, 1.666667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "f_orchard_32_4", -1812.61, 612.3, 887.64, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58203, "", "f_orchard_32_4", -1812.61, 612.3, 887.64, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 153118, "", "f_orchard_32_4", -1704.19, 612.3, 887.56, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "f_orchard_32_4", -1739.06, 612.3, 887.17, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup045", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion072_fire", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_fire011", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_2", "MID");
				break;
			case 15:
				await track.Dialog.Msg("ORCHARD_324_MQ_06_track_01");
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "MID");
				break;
			case 25:
				await track.Dialog.Msg("ORCHARD_324_MQ_06_track_02");
				break;
			case 29:
				await track.Dialog.Msg("ORCHARD_324_MQ_06_track_03");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_red", "BOT");
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_red", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_red_1", "BOT");
				break;
			case 43:
				//DRT_ADDBUFF("SoulDuel_DEF", 1, 0, 0, 1);
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 48:
				character.AddonMessage("NOTICE_Dm_!", "The sorcerer disappeared after taking unstable Kruvina!{nl}Defeat Zaura who received powers from Giltine", 3);
				break;
			case 49:
				//TRACK_SETTENDENCY();
				//SetFixAnim("event_stop");
				//DRT_RUN_FUNCTION("ORCHARD324_CLEAR_BUFF");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
