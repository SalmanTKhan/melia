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

[TrackScript("EP16_1_CORAL_32_1_MQ6_TRACK")]
public class EP161CORAL321MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_CORAL_32_1_MQ6_TRACK");
		//SetMap("f_coral_32_1");
		//CenterPos(1156.63,226.10,915.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160196, "", "f_coral_32_1", 1214.928, 226.1049, 1018.976, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1241.221f, 226.1049f, 933.318f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59828, "", "f_coral_32_1", 1172.482, 226.1049, 1173.076, 0);
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
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic032_blue_line", "BOT");
				break;
			case 21:
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in011", "MID");
				break;
			case 58:
				//DRT_PLAY_MGAME("EP16_1_CORAL_32_1_MQ6_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
