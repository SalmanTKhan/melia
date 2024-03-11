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

[TrackScript("KATYN_12_MQ_06_TRACK")]
public class KATYN12MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_12_MQ_06_TRACK");
		//SetMap("f_katyn_12");
		//CenterPos(355.53,249.46,-1055.59);
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
			case 1:
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_01");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_02");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_03");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_04");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_05");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground12_blue", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "MID");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_03");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_05");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_01");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_04");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_02");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				//DRT_RUN_FUNCTION("SCR_KATYN_12_MQ_06_TRACK_CRYSTAL_DUMMY");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere009_violet", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
