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

[TrackScript("ORCHARD_323_MQ_05_TRACK")]
public class ORCHARD323MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_323_MQ_05_TRACK");
		//SetMap("f_orchard_32_3");
		//CenterPos(415.35,0.87,-259.98);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47150, "", "f_orchard_32_3", 392.4512, 0.8661499, -251.9003, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57864, "", "f_orchard_32_3", 285.7182, 0.8661499, -200.1559, 6.666667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 95;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57854, "", "f_orchard_32_3", 399.6137, 0.8661499, -301.2908, 6.428572);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57854, "", "f_orchard_32_3", 400.0392, 0.8661499, -158.1108, 25.90909);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57852, "", "f_orchard_32_3", 501.5771, 0.8661499, -348.4342, 29.58333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(425.8449f, 0.8661499f, -270.6299f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 57853, "", "f_orchard_32_3", 369.6173, 0.8661499, -300.4341, 6.785715);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57853, "", "f_orchard_32_3", 409.7375, 0.8661499, -325.4789, 4.821429);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57852, "", "f_orchard_32_3", 442.1876, 0.8661499, -231.6409, 7.307693);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_orchard_32_3", 289.8777, 0.8661499, -201.4825, 0);
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
			case 3:
				character.AddonMessage("NOTICE_Dm_!", "Ferret Marauder, protector of the Demon Totems has appeared!", 3);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "TOP", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "TOP", 0);
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "TOP", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "TOP", 0);
				break;
			case 59:
				break;
			case 60:
				break;
			case 62:
				break;
			case 63:
				break;
			case 64:
				break;
			case 66:
				break;
			case 74:
				character.AddonMessage("NOTICE_Dm_!", "Eliminate Ferret Marauder and destroy the Demon Totem!", 3);
				break;
			case 75:
				//TRACK_SETTENDENCY();
				break;
			case 76:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 84:
				//DRT_RUN_FUNCTION("ORCHARD323_MQ_05_BOSS_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
