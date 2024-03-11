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

[TrackScript("CATACOMB_38_1_SQ_07_AFTER_TRACK")]
public class CATACOMB381SQ07AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_38_1_SQ_07_AFTER_TRACK");
		//SetMap("id_catacomb_38_1");
		//CenterPos(1177.25,241.76,1294.68);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154016, "", "id_catacomb_38_1", 1072.212, 253.3692, 1057.915, 41);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1150.367f, 241.7631f, 1261.079f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20117, "", "id_catacomb_38_1", 1050.234, 253.3692, 1033.067, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20138, "", "id_catacomb_38_1", 1041.566, 253.3692, 1046.706, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20147, "", "id_catacomb_38_1", 1063.074, 253.3692, 1087.211, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				break;
			case 15:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle020_light", "BOT");
				break;
			case 36:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out003_light", "arrow_cast", "F_cleric_ausirine_shot_light", "arrow_blow", "SLOW", 15, 1, 40, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out003_light", "arrow_cast", "F_cleric_ausirine_shot_light", "arrow_blow", "SLOW", 15, 1, 40, 5, 10, 0);
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out003_light", "arrow_cast", "F_cleric_ausirine_shot_light", "arrow_blow", "SLOW", 15, 1, 40, 5, 10, 0);
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
