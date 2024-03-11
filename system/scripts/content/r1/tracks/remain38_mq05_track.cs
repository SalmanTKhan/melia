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

[TrackScript("REMAIN38_MQ05_TRACK")]
public class REMAIN38MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAIN38_MQ05_TRACK");
		//SetMap("f_remains_38");
		//CenterPos(1457.39,370.21,869.39);
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
			case 7:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet", "BOT");
				break;
			case 19:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_!", "Chapparition appeared while rubbing the inscription!{nl}Defeat Chapparition!", 3);
				//TRACK_SETTENDENCY();
				break;
			case 27:
				//SetFixAnim("astd");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
