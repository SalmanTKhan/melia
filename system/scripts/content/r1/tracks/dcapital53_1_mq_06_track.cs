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

[TrackScript("DCAPITAL53_1_MQ_06_TRACK")]
public class DCAPITAL531MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL53_1_MQ_06_TRACK");
		//SetMap("f_desolated_capital_53_1");
		//CenterPos(1813.17,111.87,2245.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1813.174f, 111.8744f, 2245.279f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 40120, "", "f_desolated_capital_53_1", 1515.549, 111.8744, 2274.188, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "", "f_desolated_capital_53_1", 1743.164, 111.8744, 2199.075, 1.323529);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156005, "", "f_desolated_capital_53_1", 1760, 112, 2301, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 157004, "", "f_desolated_capital_53_1", 1755, 112, 2330, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 157005, "", "f_desolated_capital_53_1", 1784, 111, 2342, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154102, "", "f_desolated_capital_53_1", 1756.654, 111.8744, 2260.126, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147448, "", "f_desolated_capital_53_1", 1722.389, 111.8744, 2195.296, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47239, "", "f_desolated_capital_53_1", 1762.012, 111.8744, 2188.007, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57223, "", "f_desolated_capital_53_1", 1746.388, 111.8744, 2216.741, 0, "Neutral");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 156043, "", "f_desolated_capital_53_1", 1717.227, 113.6068, 2297.327, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 154072, "", "f_desolated_capital_53_1", 1561.596, 111.8744, 2281.246, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147452, "", "f_desolated_capital_53_1", 1688.176, 112.2682, 2330.711, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 154010, "", "f_desolated_capital_53_1", 1592.4, 111.8744, 2301.744, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 154066, "", "f_desolated_capital_53_1", 1677.78, 111.87, 2248.62, 0);
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
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground141_light_blue_loop", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 45:
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				break;
			case 85:
				await track.Dialog.Msg("DCAPITAL53_1_MQ_06_DLG02");
				break;
			case 119:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 132:
				break;
			case 136:
				await track.Dialog.Msg("DCAPITAL53_1_MQ_06_DLG03");
				break;
			case 147:
				break;
			case 149:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop3", "BOT");
				break;
			case 172:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue2", "TOP", 0);
				break;
			case 179:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue2", "TOP", 0);
				break;
			case 193:
				//DRT_ACTOR_PLAY_EFT("F_cleric_godsmash_shot_explosion", "BOT", 0);
				break;
			case 195:
				//DRT_RUN_FUNCTION("SCR_DCAPITAL53_1_MQ_06_EFFECT_ATTACH");
				break;
			case 216:
				//DRT_RUN_FUNCTION("SCR_DCAPITAL53_1_MQ_06_EFFECT_DETACH");
				break;
			case 236:
				await track.Dialog.Msg("DCAPITAL53_1_MQ_06_DLG04");
				break;
			case 239:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground141_light_blue_loop", "BOT");
				break;
			case 241:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 272:
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				break;
			case 287:
				character.AddonMessage("NOTICE_Dm_Clear", "Bring Neringa in using Neringa’s Candle.", 10);
				break;
			case 289:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
