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

[TrackScript("CASTLE94_MAIN07_AFTER_TRACK")]
public class CASTLE94MAIN07AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE94_MAIN07_AFTER_TRACK");
		//SetMap("f_castle_94");
		//CenterPos(565.65,289.92,2870.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(539.9718f, 289.9216f, 2832.603f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152023, "", "f_castle_94", 575, 289, 2887, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 326.7204, 289.9216, 2870.136, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 440.5044, 289.9216, 2675.412, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 370.5081, 289.9216, 2758.542, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 552.9793, 289.9216, 2649.173, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 596.2001, 289.9216, 2613.218, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 461.2717, 289.9216, 2611.315, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 327.5919, 289.9216, 2773.671, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59222, "", "f_castle_94", 303.6333, 289.9216, 2899.805, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 293.5298, 289.9216, 2824.996, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 343.5231, 289.9216, 2704.848, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 390.8306, 289.9216, 2643.066, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 521.4666, 289.9216, 2597.892, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 326.7204, 289.9216, 2870.136, 395);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 440.5044, 289.9216, 2675.412, 395);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 370.5081, 289.9216, 2758.542, 395);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 552.9793, 289.9216, 2649.173, 395);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 596.2001, 289.9216, 2613.218, 395);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 461.2717, 289.9216, 2611.315, 395);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 327.5919, 289.9216, 2773.671, 395);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 303.6333, 289.9216, 2899.805, 395);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 293.5298, 289.9216, 2824.996, 395);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 343.5231, 289.9216, 2704.848, 395);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 390.8306, 289.9216, 2643.066, 1.511628);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 40095, "", "f_castle_94", 521.4666, 289.9216, 2597.892, 395);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 154065, "", "f_castle_94", 575, 289, 2887, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_burstup051_dark", "BOT", 0);
				break;
			case 24:
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 115:
				character.AddSessionObject(PropertyName.CASTLE94_MAIN07, 1);
				break;
			case 119:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
