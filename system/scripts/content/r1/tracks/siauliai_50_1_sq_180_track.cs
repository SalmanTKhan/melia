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

[TrackScript("SIAULIAI_50_1_SQ_180_TRACK")]
public class SIAULIAI501SQ180TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_50_1_SQ_180_TRACK");
		//SetMap("f_siauliai_50_1");
		//CenterPos(92.10,-117.91,621.62);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153025, "", "f_siauliai_50_1", 34.11, -117.91, 709.51, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", -47.93, -117.91, 787.24, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", -2.86, -117.91, 805.43, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", -34.38, -117.91, 863.36, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", 120.62, -117.91, 746.31, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", 174.6, -117.91, 771.88, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47200, "UnvisibleName", "f_siauliai_50_1", 153.68, -117.91, 852.45, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 400543, "", "f_siauliai_50_1", -64.83675, -117.9135, 776.9301, 7.857143);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 400543, "", "f_siauliai_50_1", -21.60198, -117.9135, 883.8959, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 400543, "", "f_siauliai_50_1", -133.0393, -117.9135, 730.0465, 57.85714);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", 186.4985, -117.9135, 605.4955, 35);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", -20.04765, -117.9135, 729.1603, 41.5);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", 156.8966, -117.9135, 778.3848, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", 235.4142, -117.9135, 677.227, 65.83333);
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
			case 2:
				character.AddonMessage("NOTICE_Dm_!", "Rampaging monsters are eyeing you!", 4);
				break;
			case 5:
				break;
			case 8:
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("E_spread_out01_leaf", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("E_spread_out01_leaf", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("E_spread_out01_leaf", "BOT", 0);
				break;
			case 19:
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
