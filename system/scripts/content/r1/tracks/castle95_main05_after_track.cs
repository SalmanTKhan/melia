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

[TrackScript("CASTLE95_MAIN05_AFTER_TRACK")]
public class CASTLE95MAIN05AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE95_MAIN05_AFTER_TRACK");
		//SetMap("f_castle_95");
		//CenterPos(256.94,292.53,310.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(257.8624f, 292.5268f, 316.091f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147414, "", "f_castle_95", 175, 292, 316, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153015, "", "f_castle_95", 248, 292, 263, 0.625);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153015, "", "f_castle_95", 248, 292, 299, 163.75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153015, "", "f_castle_95", 248, 292, 335, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153015, "", "f_castle_95", 248, 292, 371, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147501, "", "f_castle_95", 175, 292, 316, 0);
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
			case 14:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("I_spread_in001_dark", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue3", "BOT", 0);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
