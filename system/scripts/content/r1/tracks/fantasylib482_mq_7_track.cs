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

[TrackScript("FANTASYLIB482_MQ_7_TRACK")]
public class FANTASYLIB482MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB482_MQ_7_TRACK");
		//SetMap("d_fantasylibrary_48_2");
		//CenterPos(848.25,268.71,-240.69);
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
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_1");
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_light059", "MID", 0);
				break;
			case 9:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_2");
				break;
			case 10:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_3");
				break;
			case 11:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_4");
				break;
			case 12:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_5");
				break;
			case 13:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_6");
				break;
			case 14:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_7");
				break;
			case 15:
				await track.Dialog.Msg("FANTASYLIB482_MQ_7_T_8");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke001_dark_3", "BOT");
				break;
			case 49:
				character.AddSessionObject(PropertyName.FANTASYLIB482_MQ_7, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
