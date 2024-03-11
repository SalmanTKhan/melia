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

[TrackScript("PILGRIM47_SQ_070_TRACK")]
public class PILGRIM47SQ070TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM47_SQ_070_TRACK");
		//SetMap("None");
		//CenterPos(1560.31,246.82,1909.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155032, "UnvisibleName", "None", 1500.48, 246.81, 1817.77, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57444, "", "None", 1492.869, 246.8158, 1809.797, 30);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1523.048f, 246.8158f, 1796.078f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground077_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion074_violet", "BOT");
				break;
			case 24:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_spread_out002", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
