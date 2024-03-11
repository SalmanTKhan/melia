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

[TrackScript("FTOWER43_MQ_05_TRACK")]
public class FTOWER43MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER43_MQ_05_TRACK");
		//SetMap("d_firetower_43");
		//CenterPos(449.29,359.31,-538.81);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_red", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion024_rize", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion081_smoke", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion081_smoke", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_red", "BOT");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "The Mineloader is online!{nl}Defeat Mineloader!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
