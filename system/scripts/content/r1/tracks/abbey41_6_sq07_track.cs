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

[TrackScript("ABBEY41_6_SQ07_TRACK")]
public class ABBEY416SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY41_6_SQ07_TRACK");
		//SetMap("None");
		//CenterPos(0.00,0.00,0.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(958.12f, 54.01793f, 147.4299f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "None", 949.29, 53.31, 172.79, 73.18182);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151022, "UnVisibleName", "None", 545.36, 10.18, -276.44, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "None", 524.8358, 0.1776352, -295.1026, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "None", 662.677, 0.177613, -208.9773, 0);
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
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 25:
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in022_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 39:
				//DRT_RUN_FUNCTION("SCR_ABBEY41_6_SQ07_OBJ");
				//DRT_RUN_FUNCTION("SCR_ABBEY41_6_SQ07_OBJ");
				break;
			case 40:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("ABBEY41_6_SQ07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
