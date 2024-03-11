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

[TrackScript("CATACOMB_25_4_SQ_110_TRACK")]
public class CATACOMB254SQ110TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_25_4_SQ_110_TRACK");
		//SetMap("id_catacomb_25_4");
		//CenterPos(1416.89,-14.34,588.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155044, "", "id_catacomb_25_4", 1273.897, -14.34392, 716.669, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155045, "", "id_catacomb_25_4", 1323.278, -14.34391, 724.9501, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1435.307f, -14.3439f, 592.9534f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 147466, "", "id_catacomb_25_4", 1321.702, -14.34391, 679.6506, 2.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", 1174.287, -14.344, 704.2427, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", 1272.427, -14.34394, 601.9393, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", 1171.807, -14.34396, 611.8557, 0);
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
			case 39:
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic021_yellow_fire", "BOT");
				//DRT_ADDBUFF("CATACOMB_25_4_BUFF", 1, 0, 0, 1);
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic032_yellow_line", "BOT");
				break;
			case 45:
				break;
			case 46:
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "BOT");
				break;
			case 48:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "BOT");
				break;
			case 54:
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 56:
				//DRT_PLAY_MGAME("CATACOMB_25_4_SQ_110_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
