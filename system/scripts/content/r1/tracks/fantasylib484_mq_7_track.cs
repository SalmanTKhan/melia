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

[TrackScript("FANTASYLIB484_MQ_7_TRACK")]
public class FANTASYLIB484MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB484_MQ_7_TRACK");
		//SetMap("None");
		//CenterPos(1646.34,319.74,996.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1564.226f, 319.743f, 1004.384f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154104, "", "None", 1653.936, 319.743, 957.7489, 0);
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
			case 8:
				//DRT_PLAY_MGAME("FANTASYLIB484_MQ_7_MINI");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect the Ballandans Collapsing Device!", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
