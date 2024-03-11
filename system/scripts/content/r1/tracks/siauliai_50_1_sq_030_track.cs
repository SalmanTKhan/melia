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

[TrackScript("SIAULIAI_50_1_SQ_030_TRACK")]
public class SIAULIAI501SQ030TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_50_1_SQ_030_TRACK");
		//SetMap("f_siauliai_50_1");
		//CenterPos(-1103.56,0.21,-1385.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47203, "UnvisibleName", "f_siauliai_50_1", -1143.51, 0.2, -1374.93, 35);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-985.2213f, 0.2093f, -1432.129f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 151024, "", "f_siauliai_50_1", -1131.625, 0.2093, -1385.059, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", -866.1123, 0.2093, -1452.852, 92.14286);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400563, "", "f_siauliai_50_1", -944.4561, 0.2093, -1522.762, 84.28571);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_spark008_leaf", "MID", 0);
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_leaf001_green", "MID", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_spark008_leaf", "MID", 0);
				break;
			case 6:
				break;
			case 10:
				break;
			case 14:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("SIAULIAI50_MINI02");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
