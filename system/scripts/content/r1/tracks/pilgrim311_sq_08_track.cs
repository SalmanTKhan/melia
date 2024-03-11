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

[TrackScript("PILGRIM311_SQ_08_TRACK")]
public class PILGRIM311SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM311_SQ_08_TRACK");
		//SetMap("f_pilgrimroad_31_1");
		//CenterPos(132.67,1.07,-432.55);
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
			case 9:
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "TOP");
				break;
			case 24:
				break;
			case 48:
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "Defeat Chaser Werewolf!", 3);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
