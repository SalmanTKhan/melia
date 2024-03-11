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

[TrackScript("REMAINS37_1_SQ_020_TRACK")]
public class REMAINS371SQ020TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_1_SQ_020_TRACK");
		//SetMap("f_remains_37_1");
		//CenterPos(1625.86,274.28,-1079.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 152030, "UnvisibleName", "f_remains_37_1", 1609.23, 274.28, -1013.03, 1);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(1602.433f, 274.2816f, -1034.595f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57620, "", "f_remains_37_1", 1480.278, 274.2816, -1122.951, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57620, "", "f_remains_37_1", 1466.553, 274.2816, -1080.164, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57620, "", "f_remains_37_1", 1577.397, 274.2816, -1137.477, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 5:
				break;
			case 8:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("REMAINS37_1_SQ_020_MINI");
				break;
			case 9:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
