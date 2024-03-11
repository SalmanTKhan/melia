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

[TrackScript("EP16_1_CORAL_32_1_MQ4_TRACK")]
public class EP161CORAL321MQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_CORAL_32_1_MQ4_TRACK");
		//SetMap("f_coral_32_1");
		//CenterPos(813.73,142.95,-364.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160196, "", "f_coral_32_1", 1482.748, 225.3368, -36.52988, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(801.9484f, 142.9497f, -349.4021f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_only_quest_smoke013_blue_smoke", "MID");
				break;
			case 24:
				//DRT_PLAY_MGAME("EP16_1_CORAL_32_1_MQ4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
