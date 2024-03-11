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

[TrackScript("ABBAY_64_3_MQ040_TRACK")]
public class ABBAY643MQ040TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBAY_64_3_MQ040_TRACK");
		//SetMap("d_abbey_64_3");
		//CenterPos(-1485.68,585.72,-470.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153110, "Edmundas", "d_abbey_64_3", -1513, 584.96, -473, 83.23529);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1485.683f, 585.72f, -470.3501f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "d_abbey_64_3", -1459, 622.42, 175, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153120, "", "d_abbey_64_3", -1454.404, 622.4191, 244.9632, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41380, "", "d_abbey_64_3", -1369.303, 622.4191, 369.399, 71.92308);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47123, "UnvisibleName", "d_abbey_64_3", -1459.859, 622.4191, 175.4431, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20046, "", "d_abbey_64_3", -1457.648, 622.4191, 245.5021, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47254, "UnvisibleName", "d_abbey_64_3", -1555, 621, 268, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_levitation015_dark", "BOT", 0);
				break;
			case 35:
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_levitation015_dark", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_levitation015_dark", "BOT", 0);
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_levitation015_dark", "BOT", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_spin009", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("I_sphere011_mash", "BOT", 0);
				break;
			case 69:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
