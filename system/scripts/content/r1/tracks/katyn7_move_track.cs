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

[TrackScript("KATYN7_MOVE_TRACK")]
public class KATYN7MOVETRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN7_MOVE_TRACK");
		//SetMap("f_katyn_7");
		//CenterPos(1025.54,295.72,-4012.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41207, "", "f_katyn_7", 1044.733, 295.7045, -3331.2, 61.92308);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20016, "", "f_katyn_7", 969.5404, 295.645, -3789.443, 63.23529);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20016, "", "f_katyn_7", 1033.624, 295.6341, -3791.558, 62.05882);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20016, "", "f_katyn_7", 994.6768, 295.7045, -3504.084, 98.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20016, "", "f_katyn_7", 770.1633, 295.6945, -3685.796, 77.64706);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20016, "", "f_katyn_7", 1147.047, 295.7045, -3548.838, 76.42857);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var npc0 = Shortcuts.AddNpc(0, 20016, "Scout", "f_katyn_7", 995.519, 295.7083, -3989.825, 81);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
