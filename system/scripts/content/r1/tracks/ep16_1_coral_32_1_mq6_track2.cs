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

[TrackScript("EP16_1_CORAL_32_1_MQ6_TRACK2")]
public class EP161CORAL321MQ6TRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_CORAL_32_1_MQ6_TRACK2");
		//SetMap("None");
		//CenterPos(1243.29,226.10,1062.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160196, "", "None", 1254.974, 226.1049, 998.0013, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1220.775f, 226.1049f, 933.865f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59828, "", "None", 1177.33, 226.1049, 1164.777, 0);
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
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_dark_green", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup017_dark2", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
