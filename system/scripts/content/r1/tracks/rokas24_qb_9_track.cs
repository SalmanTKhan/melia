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

[TrackScript("ROKAS24_QB_9_TRACK")]
public class ROKAS24QB9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS24_QB_9_TRACK");
		//SetMap("f_rokas_24");
		//CenterPos(-1438.68,895.28,-1314.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20117, "Gorath", "f_rokas_24", -1468, 895, -1328, 47.77778);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1447.593f, 895.2841f, -1333.614f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57076, "", "f_rokas_24", -1315.515, 895.2841, -1273.136, 130);
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
			case 9:
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke015_green", "BOT");
				break;
			case 29:
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
