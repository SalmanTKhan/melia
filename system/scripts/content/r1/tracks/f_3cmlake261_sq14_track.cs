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

[TrackScript("F_3CMLAKE261_SQ14_TRACK")]
public class F3CMLAKE261SQ14TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ14_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(-402.02,-59.75,-1237.91);
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
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_exclamation_dark", "TOP", 0);
				break;
			case 31:
				character.AddonMessage("NOTICE_Dm_scroll", "The Tutu senses your presence and attacks!", 3);
				break;
			case 49:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
