using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP12_2_F_DACPITAL_104_MQ01_TRACK_01")]
public class EP122FDACPITAL104MQ01TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_DACPITAL_104_MQ01_TRACK_01");
		//SetMap("f_dcapital_104");
		//CenterPos(633.36,160.52,1958.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154040, "", "f_dcapital_104", 624.004, 159.3028, 1983.544, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(635.048f, 161.1363f, 1946.443f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_SET");
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_DACPITAL_104_MQ01_DLG_03", 3);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_light106_drop", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_light010", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_DACPITAL_104_MQ01_TRACK_DAYLIGHT_CLEAR");
				break;
			case 39:
				await track.Dialog.Msg("EP12_2_F_DACPITAL_104_MQ01_DLG_04");
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
