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

[TrackScript("STARTOWER_90_MQ_60_TRACK")]
public class STARTOWER90MQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_90_MQ_60_TRACK");
		//SetMap("d_startower_90");
		//CenterPos(112.99,64.15,458.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(112.8381f, 64.2745f, 445.7289f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20042, "", "d_startower_90", 8, 62, 948, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47236, "", "d_startower_90", 8, 62, 948, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20042, "", "d_startower_90", 56, 63, 1003, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 52:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 83:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 90:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange##1.5", "BOT", 0);
				break;
			case 97:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 105:
				//DRT_ACTOR_PLAY_EFT("F_burstup018_dark", "BOT", 0);
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "MID", 0);
				break;
			case 137:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 148:
				character.AddonMessage("NOTICE_Dm_Clear", "The girl's power removed the invisible barrier!{nl}Return to Byle and talk to him about what to do next.", 3);
				break;
			case 149:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
