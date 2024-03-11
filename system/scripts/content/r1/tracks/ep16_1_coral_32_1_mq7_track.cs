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

[TrackScript("EP16_1_CORAL_32_1_MQ7_TRACK")]
public class EP161CORAL321MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_CORAL_32_1_MQ7_TRACK");
		//SetMap("f_coral_32_1");
		//CenterPos(1179.23,226.10,1153.30);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160196, "", "f_coral_32_1", 1169, 226, 1199, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1180.193f, 226.1049f, 1133.772f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in009_violet2", "MID");
				break;
			case 23:
				//DRT_RUN_FUNCTION("SCR_EP16_1_CORAL_32_1_MQ7_SET_SSN_QUEST_VALUE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
