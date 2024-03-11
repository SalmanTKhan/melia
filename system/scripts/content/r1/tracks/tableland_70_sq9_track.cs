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

[TrackScript("TABLELAND_70_SQ9_TRACK")]
public class TABLELAND70SQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_70_SQ9_TRACK");
		//SetMap("f_tableland_70");
		//CenterPos(3092.59,561.63,-2501.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103037, "", "f_tableland_70", 3095.62, 561.62, -2522.2, 20.86957, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 2712.697, 561.3273, -2579.565, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3319.884, 561.6254, -2566.381, 59.375);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 2994.55, 561.62, -2300.67, 62.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 2919.16, 561.62, -2276.17, 48.63636);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3060.24, 561.62, -2614.78, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3227.85, 561.62, -2555.16, 30.95238);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 103038, "", "f_tableland_70", 2516.124, 561.2588, -2707.957, 32.85714);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57973, "", "f_tableland_70", 2547.184, 561.2588, -2807.315, 23.84616);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57973, "", "f_tableland_70", 2406.185, 561.2588, -2674.32, 18.84616);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57973, "", "f_tableland_70", 2469.931, 561.2588, -2603.59, 27.27273);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57967, "", "f_tableland_70", 2611.521, 561.2588, -2778.403, 23.75);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 57967, "", "f_tableland_70", 2455.59, 561.2588, -2667.499, 21.36364);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 57967, "", "f_tableland_70", 2552.445, 561.2588, -2751.623, 15.83333);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var npc0 = Shortcuts.AddNpc(0, 41452, "UnvisibleName", "f_tableland_70", 2684.161, 561.2588, -2713.935, 31.66667);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 41452, "UnvisibleName", "f_tableland_70", 2561.366, 561.2588, -2576.547, 216.6667);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var npc2 = Shortcuts.AddNpc(0, 41452, "UnvisibleName", "f_tableland_70", 2659.422, 561.2588, -2607.176, 192.5);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		character.Movement.MoveTo(new Position(3092.594f, 561.6254f, -2501.252f));
		actors.Add(character);

		var mob14 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 2693.504, 561.2747, -2508.934, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 155008, "", "f_tableland_70", 3030.35, 561.62, -2569.71, 18.6);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 151029, "", "f_tableland_70", 3000.79, 561.62, -2550.59, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var npc3 = Shortcuts.AddNpc(0, 41452, "", "f_tableland_70", 2657.484, 561.2588, -2667.098, 0);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var npc4 = Shortcuts.AddNpc(0, 41452, "", "f_tableland_70", 2655.603, 561.2588, -2533.894, 0);
		npc4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc4.AddEffect(new ScriptInvisibleEffect());
		npc4.Layer = character.Layer;
		actors.Add(npc4);

		var mob17 = Shortcuts.AddMonster(0, 57967, "", "f_tableland_70", 2449.54, 561.2588, -2722.615, 65);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 151029, "UnvisibleName", "f_tableland_70", 3008.87, 561.62, -2308.61, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 153158, "", "f_tableland_70", 2582.573, 561.2588, -2616.989, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 153158, "", "f_tableland_70", 2616.155, 561.2588, -2640.131, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 153158, "", "f_tableland_70", 2696.546, 561.2588, -2652.635, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 153158, "", "f_tableland_70", 2585.01, 561.2588, -2554.044, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 41452, "", "f_tableland_70", 2542.279, 561.2588, -2616.549, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "TOP");
				//DRT_ACTOR_PLAY_EFT("stake_stockades_01_dead", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "TOP");
				//DRT_ACTOR_PLAY_EFT("stake_stockades_01_dead", "BOT", 0);
				break;
			case 66:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
