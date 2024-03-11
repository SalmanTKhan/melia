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

[TrackScript("CASTLE94_MAIN06_AFTER_TRACK")]
public class CASTLE94MAIN06AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE94_MAIN06_AFTER_TRACK");
		//SetMap("f_castle_94");
		//CenterPos(-1389.75,289.92,1003.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151050, "", "f_castle_94", -1416, 289, 1000, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1298.255f, 289.9216f, 1032.387f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 153156, "", "f_castle_94", -1366, 289, 950, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153156, "", "f_castle_94", -1466, 289, 950, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153156, "", "f_castle_94", -1366, 289, 1050, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153156, "", "f_castle_94", -1466, 289, 1050, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150201, "", "f_castle_94", 188, 289, 2459, 0);
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
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_bg_light003_blue2", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_blue2", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic009_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic009_blue", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic018_blue_fire", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic018_blue_fire_1", "BOT", 0);
				break;
			case 58:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
