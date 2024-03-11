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

[TrackScript("BRACKEN42_2_SQ10_TRACK")]
public class BRACKEN422SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN42_2_SQ10_TRACK");
		//SetMap("f_bracken_42_2");
		//CenterPos(1179.40,-73.92,-188.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(860.8385f, -78.34486f, -192.2623f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 58526, "", "f_bracken_42_2", 1522.257, -73.91946, -1.544981, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58526, "", "f_bracken_42_2", 902.0644, -73.91946, -214.7946, 0);
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
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "MID");
				break;
			case 15:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 55:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
