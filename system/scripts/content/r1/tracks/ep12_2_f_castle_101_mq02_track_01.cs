using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP12_2_F_CASTLE_101_MQ02_TRACK_01")]
public class EP122FCASTLE101MQ02TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ02_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(480.77,124.55,378.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(480.7714f, 124.5478f, 378.4618f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150212, "[랑다", "f_castle_101", 460.5678, 124.5478, 353.9505, 88.21429);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150230, "", "f_castle_101", 885.4235, 124.5477, 412.9458, 3.888889);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 832.6201, 124.5477, 454.8607, 7.368421);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 864.003, 124.5477, 372.8607, 9.736842);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 699.0856, 124.5478, 483.1249, 0.6);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", 666.1365, 124.5478, 468.4303, 6.111111);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", 632.6851, 124.5478, 447.8371, 35.55556);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59525, "", "f_castle_101", 631.7365, 124.5478, 411.3048, 23.88889);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", 638.3509, 124.5478, 375.8188, 45.55556);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", 657.222, 124.5478, 339.8537, 67.77778);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 690.3732, 124.5478, 312.4865, 88.88889);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 150216, "", "f_castle_101", 814.0993, 124.5477, 410.2602, 1.428571, "Our_Forces");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", 943.267, 124.5477, 418.676, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "f_castle_101", 896.6745, 124.5477, 456.9021, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "f_castle_101", 893.2065, 124.5477, 367.1284, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "f_castle_101", 852.3304, 124.5477, 383.2651, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "f_castle_101", 922.5076, 124.5477, 401.3027, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "f_castle_101", 847.8511, 124.5477, 445.0781, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_scout_barong_summons", "BOT", 0);
				break;
			case 49:
				break;
			case 51:
				break;
			case 53:
				break;
			case 55:
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("F_scout_rawa", "MID");
				break;
			case 64:
				//DRT_ACTOR_ATTACH_EFFECT("F_scout_rawa", "MID");
				break;
			case 65:
				//DRT_ACTOR_ATTACH_EFFECT("F_scout_rawa", "MID");
				break;
			case 66:
				//DRT_ACTOR_ATTACH_EFFECT("F_scout_rawa", "MID");
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_scout_rawa", "MID");
				break;
			case 74:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP12_2_F_CASTLE_101_MQ02_MINI");
				CreateBattleBoxInLayer(character, track);
				//DRT_RUN_FUNCTION("SCR_SUMMON_BARONG");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
