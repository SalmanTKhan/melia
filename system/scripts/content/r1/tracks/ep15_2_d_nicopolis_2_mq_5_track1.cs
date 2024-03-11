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

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_5_TRACK1")]
public class EP152DNICOPOLIS2MQ5TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_5_TRACK1");
		//SetMap("ep15_2_d_nicopolis_2");
		//CenterPos(248.76,1.00,-941.62);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(200.9423f, 1f, -986.8313f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 160065, "", "ep15_2_d_nicopolis_2", -2.327799, 1, -918.7014, 0);
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
			case 11:
				Send.ZC_NORMAL.Notice(character, "EP15_2_D_NICOPOLIS_2_MQ_5_DLG1", 3);
				break;
			case 20:
				Send.ZC_NORMAL.Notice(character, "EP15_2_D_NICOPOLIS_2_MQ_5_DLG2", 3);
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
