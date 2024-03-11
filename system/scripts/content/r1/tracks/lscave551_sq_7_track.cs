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

[TrackScript("LSCAVE551_SQ_7_TRACK")]
public class LSCAVE551SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LSCAVE551_SQ_7_TRACK");
		//SetMap("d_limestonecave_55_1");
		//CenterPos(1370.60,137.37,927.87);
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
			case 29:
				character.AddonMessage("NOTICE_Dm_!", "Please, defeat Ravinepede!", 8);
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
