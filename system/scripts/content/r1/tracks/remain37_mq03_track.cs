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

[TrackScript("REMAIN37_MQ03_TRACK")]
public class REMAIN37MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAIN37_MQ03_TRACK");
		//SetMap("f_remains_37");
		//CenterPos(1182.12,1056.92,-2155.40);
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
			case 5:
				character.AddonMessage("NOTICE_Dm_!", "This doesn't look like the stone plate which you are looking for!", 3);
				break;
			case 15:
				break;
			case 17:
				character.AddonMessage("NOTICE_Dm_!", "Achat appeared just like Raymond said!", 3);
				break;
			case 39:
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
