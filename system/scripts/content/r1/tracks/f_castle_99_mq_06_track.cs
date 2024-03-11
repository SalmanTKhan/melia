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

[TrackScript("F_CASTLE_99_MQ_06_TRACK")]
public class FCASTLE99MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_99_MQ_06_TRACK");
		//SetMap("f_castle_99");
		//CenterPos(-1745.91,68.16,-420.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1745.912f, 68.15691f, -420.866f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151041, "", "f_castle_99", -1782.913, 68.15165, -453.1856, 66.31579);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156159, "", "f_castle_99", -1656.09, 55.07813, 63.03667, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_castle_99", -1719.467, 55.00492, -1.505611, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 105030, "", "f_castle_99", -1618.696, 55.07942, -30.32412, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150210, "", "f_castle_99", -1720.955, 55.00174, -0.2717886, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 24:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG1");
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("I_spread_in010_mintdark", "MID", 0);
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_rize002_violet2", "BOT");
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_rize022", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_ground_rize_debuff_loop1", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_explosion019_rize", "MID", 0);
				break;
			case 36:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG2");
				break;
			case 39:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG3");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_ground173", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_ground174_dark", "BOT", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_hit001_light_dark", "MID", 0);
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 66:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 70:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 71:
				break;
			case 75:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG4");
				break;
			case 77:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG5");
				break;
			case 79:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG6");
				break;
			case 84:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG7");
				break;
			case 86:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG8");
				break;
			case 88:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG9");
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_hit_dark2", "BOT", 0);
				break;
			case 94:
				//DRT_PLAY_FORCE(0, 1, 6, "I_force019_pink", "arrow_cast", "None", "None", "SLOW", 75, 1, 0, 5, 10, 0);
				break;
			case 102:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG10");
				break;
			case 104:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG11");
				break;
			case 106:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG12");
				break;
			case 109:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG13");
				break;
			case 110:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 112:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 120:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 133:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG14");
				break;
			case 134:
				//DRT_ACTOR_PLAY_EFT("F_ground134_red_noloop", "BOT", 0);
				break;
			case 137:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				break;
			case 141:
				await track.Dialog.Msg("F_CASTLE_99_MQ_06_TRACK_DLG15");
				break;
			case 144:
				//DRT_ACTOR_PLAY_EFT("F_light059", "MID", 0);
				break;
			case 149:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "Fight off Jezebel first!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
