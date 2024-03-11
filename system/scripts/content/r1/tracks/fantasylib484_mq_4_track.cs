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

[TrackScript("FANTASYLIB484_MQ_4_TRACK")]
public class FANTASYLIB484MQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB484_MQ_4_TRACK");
		//SetMap("None");
		//CenterPos(-653.27,8.23,1183.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-611.7701f, 8.234474f, 993.7471f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154104, "", "None", -578.4205, 8.234474, 1044.441, 0);
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
			case 9:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect the Flicid Collapsing Device", 8);
				//DRT_PLAY_MGAME("FANTASYLIB484_MQ_4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
