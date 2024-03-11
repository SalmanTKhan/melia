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

[TrackScript("UNIQUE_RAID_PAST_FANTASY_LIBRARY_INTRO")]
public class UNIQUERAIDPASTFANTASYLIBRARYINTRO : TrackScript
{
	protected override void Load()
	{
		SetId("UNIQUE_RAID_PAST_FANTASY_LIBRARY_INTRO");
		//SetMap("None");
		//CenterPos(-1035.58,13.93,414.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154087, "", "None", -1011, 13, 428, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58531, "", "None", -1030, 15.23999, 480, 0, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_stop_shot_loop", "BOT");
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_spread_out032_2", "BOT", 0);
				//DRT_RUN_FUNCTION("SCR_HIDDEN_WALL_INTRO");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
