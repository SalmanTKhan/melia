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

[TrackScript("EP13_2_DPRISON1_MQ_1_TRACK_1")]
public class EP132DPRISON1MQ1TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON1_MQ_1_TRACK_1");
		//SetMap("ep13_2_d_prison_1");
		//CenterPos(-288.05,326.23,71.38);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-317.4105f, 326.1934f, 116.14f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep13_2_d_prison_1", -215.9657, 200.5001, -298.068, 29.31034);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				break;
			case 20:
				Send.ZC_NORMAL.Notice(character, "EP13_2_DPRISON1_MQ_1_DLG1", 5);
				break;
			case 35:
				character.AddonMessage("NOTICE_Dm_scroll", "Follow the Beholder!", 5);
				break;
			case 41:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
