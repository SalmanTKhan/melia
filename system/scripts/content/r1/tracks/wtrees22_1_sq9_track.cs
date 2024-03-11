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

[TrackScript("WTREES22_1_SQ9_TRACK")]
public class WTREES221SQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_1_SQ9_TRACK");
		//SetMap("f_whitetrees_22_1");
		//CenterPos(1058.19,145.85,1129.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153185, "UnvisibleName", "f_whitetrees_22_1", 1052.63, 145.85, 1182.93, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155126, "", "f_whitetrees_22_1", 1000.34, 145.85, 1146.94, 126.6667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 103047, "", "f_whitetrees_22_1", 1227.437, 145.8521, 664.4821, 82.08333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(1054.916f, 145.8521f, 1138.111f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ9_EVT_BGM1_FUNC");
				break;
			case 6:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ9_EVT_BGM2_FUNC");
				break;
			case 25:
				break;
			case 44:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
