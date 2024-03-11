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

[TrackScript("CASTLE95_MAIN07_TRACK")]
public class CASTLE95MAIN07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE95_MAIN07_TRACK");
		//SetMap("f_castle_95");
		//CenterPos(1630.35,377.03,1031.67);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1545.448f, 377.0311f, 997.2772f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154067, "", "f_castle_95", 1626, 377, 1076, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 1626, 377, 1076, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151064, "", "f_castle_95", 1630.634, 377.0229, 1053.858, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_cleric_Entity", "BOT");
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet2", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("I_spread_in007_white", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_in009_violet2", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("I_spread_in007_white", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("I_spread_in007_white", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_cleric_OOBE_shot_explosion", "BOT", 0);
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
