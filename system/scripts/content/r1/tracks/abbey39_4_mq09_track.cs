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

[TrackScript("ABBEY39_4_MQ09_TRACK")]
public class ABBEY394MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY39_4_MQ09_TRACK");
		//SetMap("None");
		//CenterPos(586.20,144.72,-1272.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 157007, "UnVisibleName", "None", 746.6182, 144.7219, -1294.28, 110);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147405, "UnVisibleName", "None", 326.0057, 144.7219, -1273.086, 123.8889);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147403, "UnVisibleName", "None", 383.1555, 144.7219, -1338.328, 102.8571);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147404, "UnVisibleName", "None", 382.7372, 144.7219, -1296.341, 96);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "UnVisibleName", "None", 689.5587, 144.7219, -1309.759, 70);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(340.7638f, 144.7219f, -1298.365f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 147403, "UnVisibleName", "None", 346.3558, 144.7219, -1289.558, 95.55556);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147404, "UnVisibleName", "None", 359.8212, 144.7219, -1265.116, 96.66667);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147403, "UnVisibleName", "None", 323.7312, 144.7219, -1322.485, 106.6667);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147406, "UnVisibleName", "None", 326.833, 144.7219, -1339.978, 98.33334);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 6:
				break;
			case 7:
				break;
			case 8:
				break;
			case 9:
				break;
			case 10:
				break;
			case 13:
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_ground103_smoke", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 0);
				break;
			case 23:
				//SetFixAnim("down");
				//SetFixAnim("down");
				break;
			case 26:
				await track.Dialog.Msg("ABBEY39_4_MQ_10_3");
				break;
			case 40:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
