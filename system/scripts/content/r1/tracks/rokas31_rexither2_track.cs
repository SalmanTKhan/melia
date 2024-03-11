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

[TrackScript("ROKAS31_REXITHER2_TRACK")]
public class ROKAS31REXITHER2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS31_REXITHER2_TRACK");
		//SetMap("f_rokas_31");
		//CenterPos(-135.90,107.10,-523.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47413, "", "f_rokas_31", -158.8563, 107.1039, -500.815, 40);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-138.1282f, 107.1039f, -522.6622f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 41348, "", "f_rokas_31", -193.91, 107.1039, -411.1744, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147345, "", "f_rokas_31", -115.5067, 107.1039, -378.5247, 33.125);
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
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_smoke1", "BOT", 0);
				break;
			case 12:
				break;
			case 39:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
