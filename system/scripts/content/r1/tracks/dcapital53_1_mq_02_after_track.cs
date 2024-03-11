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

[TrackScript("DCAPITAL53_1_MQ_02_AFTER_TRACK")]
public class DCAPITAL531MQ02AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL53_1_MQ_02_AFTER_TRACK");
		//SetMap("f_desolated_capital_53_1");
		//CenterPos(1780.22,111.87,2492.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1780.22f, 111.8744f, 2492.101f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 40120, "", "f_desolated_capital_53_1", 1515.549, 111.8744, 2274.188, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "", "f_desolated_capital_53_1", 1883.862, 111.8744, 2354.205, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156005, "", "f_desolated_capital_53_1", 1900.076, 111.8744, 2320.902, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 157004, "", "f_desolated_capital_53_1", 1851.121, 111.8744, 2362.415, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 157005, "", "f_desolated_capital_53_1", 1897.61, 111.8744, 2372.11, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2066.78, 111.87, 2250.89, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2085.82, 111.87, 2335.28, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150226, "", "f_desolated_capital_53_1", 2105.11, 111.87, 2432.84, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150221, "", "f_desolated_capital_53_1", 2060.53, 111.87, 2386.67, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150219, "", "f_desolated_capital_53_1", 2045.18, 111.87, 2299.13, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground141_light_blue_loop", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke024_blue", "BOT", 0);
				break;
			case 98:
				await track.Dialog.Msg("DCAPITAL53_1_MQ_02_DLG02");
				break;
			case 113:
				await track.Dialog.Msg("DCAPITAL53_1_MQ_02_DLG03");
				break;
			case 132:
				character.AddonMessage("NOTICE_Dm_Clear", "Bring Neringa in using Neringa’s Candle.", 10);
				break;
			case 134:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
