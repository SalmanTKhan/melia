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

[TrackScript("FTOWER43_MQ_02_TRACK")]
public class FTOWER43MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER43_MQ_02_TRACK");
		//SetMap("d_firetower_43");
		//CenterPos(-1681.25,536.99,750.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147504, "RP", "d_firetower_43", -1598.823, 554.525, 708.9035, 20.86207, "Monster");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 115;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147311, "UnvisibleName", "d_firetower_43", -1762, 537, 696, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147311, "UnvisibleName", "d_firetower_43", -1668, 537, 866, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147311, "UnvisibleName", "d_firetower_43", -1524, 537, 895, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147311, "UnvisibleName", "d_firetower_43", -1526, 536, 398, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("FTOWER43_MQ_02_MINI");
				character.AddonMessage("NOTICE_Dm_!", "Destroy the Magic Control Valve!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
