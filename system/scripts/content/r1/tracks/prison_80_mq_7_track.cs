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

[TrackScript("PRISON_80_MQ_7_TRACK")]
public class PRISON80MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_80_MQ_7_TRACK");
		//SetMap("d_prison_80");
		//CenterPos(-118.03,290.48,523.63);
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
			case 8:
				break;
			case 9:
				//DRT_ADDBUFF("PRISON_80_MQ_7_BUFF", 1, 0, 0, 1);
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_scroll", "Upon disabling the demon magic circle, Grinender appeared.{nl}Defeat Grinender.", 5);
				break;
			case 34:
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
