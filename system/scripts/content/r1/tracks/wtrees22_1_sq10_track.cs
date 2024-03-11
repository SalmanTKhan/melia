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

[TrackScript("WTREES22_1_SQ10_TRACK")]
public class WTREES221SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_1_SQ10_TRACK");
		//SetMap("f_whitetrees_22_1");
		//CenterPos(-496.97,239.41,1130.04);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153185, "UnvisibleName", "f_whitetrees_22_1", -622.99, 246.43, 1140.7, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153199, "UnvisibleName", "f_whitetrees_22_1", -567.16, 246.43, 1212.93, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153200, "UnvisibleName", "f_whitetrees_22_1", -537.21, 239.4, 1154.14, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153198, "UnvisibleName", "f_whitetrees_22_1", -558.99, 239.4, 1087.69, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155126, "메데이나", "f_whitetrees_22_1", -487.51, 239.4, 1103.47, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(-496.9669f, 239.4099f, 1130.038f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ10_EVT_BGM1_FUNC");
				//DRT_FUNC_ACT("WTREES22_1_SUBQ10_SOBJ_FUNC");
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_circle016_rainbow", "BOT", 0);
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
