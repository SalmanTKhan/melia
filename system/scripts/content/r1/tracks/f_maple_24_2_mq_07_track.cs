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

[TrackScript("F_MAPLE_24_2_MQ_07_TRACK")]
public class FMAPLE242MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_07_TRACK");
		//SetMap("f_maple_24_2");
		//CenterPos(-1192.59,8.77,687.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_2", -1285.848, 8.768949, 687.5028, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47124, "", "f_maple_24_2", -1236.311, 8.768948, 591.6752, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47124, "", "f_maple_24_2", -1209.267, 8.768949, 767.4009, 75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57578, "", "f_maple_24_2", -1283.309, 8.768951, 620.0179, 85.71429);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57579, "", "f_maple_24_2", -1274.943, 8.768948, 727.7588, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147469, "", "f_maple_24_2", -1283.437, 8.768949, 684.5901, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("I_light021_darkred", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_light021_darkred", "MID");
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_explosion013", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion013", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_light008_2", "MID", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
