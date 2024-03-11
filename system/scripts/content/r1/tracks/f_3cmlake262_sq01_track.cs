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

[TrackScript("F_3CMLAKE262_SQ01_TRACK")]
public class F3CMLAKE262SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE262_SQ01_TRACK");
		//SetMap("f_3cmlake_26_2");
		//CenterPos(817.20,-153.76,1478.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		return Array.Empty<IActor>();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("I_force036_green1", "BOT");
				break;
			case 25:
				character.AddonMessage("NOTICE_Dm_Clear", "The light from the wing is headed somewhere! Try to follow it.", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
