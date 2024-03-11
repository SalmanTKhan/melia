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

[TrackScript("Ep14_raid_Ending_TRACK")]
public class Ep14raidEndingTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("Ep14_raid_Ending_TRACK");
		//SetMap("raId_castle_ep14");
		//CenterPos(3127.03,0.50,-76.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(3067.495f, 0.4994708f, 12.0167f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59690, "UnvisibleName", "raId_castle_ep14", 3014.691, 0.4993134, 39.99545, 0.625, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154120, "", "raId_castle_ep14", 3046.087, 0.4993134, -412.9565, 57.91666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "raId_castle_ep14", 3015.422, 0.4993402, 41.63598, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59657, "", "raId_castle_ep14", 3013.529, 0.4993134, 111.3103, 0, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_SETPOS();
				break;
			case 24:
				Send.ZC_NORMAL.Notice(character, "Ep14_raid_Ending_TRACK_DLG1", 3);
				break;
			case 50:
				Send.ZC_NORMAL.Notice(character, "Ep14_raid_Ending_TRACK_DLG2", 2);
				break;
			case 71:
				Send.ZC_NORMAL.Notice(character, "Ep14_raid_Ending_TRACK_DLG3", 3);
				break;
			case 86:
				Send.ZC_NORMAL.Notice(character, "Ep14_raid_Ending_TRACK_DLG4", 3);
				break;
			case 101:
				Send.ZC_NORMAL.Notice(character, "Ep14_raid_Ending_TRACK_DLG5", 3);
				break;
			case 141:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow005_mash2", "arrow_cast", "F_spread_out004_dark", "arrow_blow", "FAST", 300, 0, 0, 1, 1, 0);
				break;
			case 144:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 170:
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_in005_dark", "BOT", 0);
				break;
			case 175:
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				break;
			case 212:
				break;
			case 222:
				//DRT_ACTOR_ATTACH_EFFECT("I_light004_violet_dark", "BOT");
				break;
			case 226:
				//DRT_ACTOR_PLAY_EFT("F_burstup006_dark", "BOT", 0);
				break;
			case 242:
				//DRT_CLEAR_EFFECT();
				break;
			case 244:
				//DRT_RUN_FUNCTION("Ep14_raid_Ending_TRACK_HEADONICON_01");
				break;
			case 269:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
