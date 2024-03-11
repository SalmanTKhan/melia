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

[TrackScript("PILGRIMROAD55_SQ04_TRACK")]
public class PILGRIMROAD55SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIMROAD55_SQ04_TRACK");
		//SetMap("f_pilgrimroad_55");
		//CenterPos(-220.23,242.42,-109.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57563, "", "f_pilgrimroad_55", 256.5255, 242.4188, -267.7762, 61.92308);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155036, "", "f_pilgrimroad_55", 158.8086, 242.4188, -295.7936, 81.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-238.5788f, 261.2097f, 64.89539f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke080", "BOT");
				break;
			case 29:
				//SetFixAnim("down");
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
