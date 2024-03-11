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

[TrackScript("ZACHA5F_EQ_03_TRACK")]
public class ZACHA5FEQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA5F_EQ_03_TRACK");
		//SetMap("d_zachariel_36");
		//CenterPos(-1540.41,332.09,-2620.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1716.951, 332.0863, -2760.41, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1742.291, 332.0863, -2651.755, 221.6667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1626.378, 332.0863, -2507.54, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1631.9, 332.09, -2591.34, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1592.276, 332.0863, -2704.9, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1694.037, 332.0863, -2607.646, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400821, "", "d_zachariel_36", -1750.89, 332.09, -2532.85, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40035, "", "d_zachariel_36", -1517.851, 334.1394, -2627.593, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		character.Movement.MoveTo(new Position(-1536.476f, 332.0863f, -2620.769f));
		actors.Add(character);

		var mob8 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1626.38, 332.09, -2507.54, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1742.29, 332.09, -2651.76, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1716.95, 332.09, -2760.41, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1631.9, 332.0863, -2591.344, 203.8889);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1592.28, 332.09, -2704.9, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1694.04, 332.09, -2607.65, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20024, "", "d_zachariel_36", -1750.888, 332.0863, -2532.85, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground074_dark", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 14:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
