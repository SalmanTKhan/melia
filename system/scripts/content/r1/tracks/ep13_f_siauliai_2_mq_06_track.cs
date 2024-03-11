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

[TrackScript("EP13_F_SIAULIAI_2_MQ_06_TRACK")]
public class EP13FSIAULIAI2MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_2_MQ_06_TRACK");
		//SetMap("ep13_f_siauliai_2");
		//CenterPos(552.62,183.66,510.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(563.0961f, 183.6621f, 503.3324f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150247, "", "ep13_f_siauliai_2", 485.286, 183.6621, 572.4147, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 161025, "", "ep13_f_siauliai_2", 489.0194, 183.6621, 572.6288, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_light013_spark_yellow", "MID", 0);
				break;
			case 25:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_2_MQ_06_DLG_T1", 3);
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
