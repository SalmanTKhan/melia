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

[TrackScript("FLASH_29_1_SQ_010_COMP_TRACK")]
public class FLASH291SQ010COMPTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_29_1_SQ_010_COMP_TRACK");
		//SetMap("None");
		//CenterPos(-541.01,43.02,-259.27);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-712.2434f, 43.08488f, -356.778f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57580, "", "None", -525.1777, 43.0867, -329.4825, 68.33333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "None", -915.1478, 38.98882, -417.9104, 64.54546);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke022", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke022", "BOT");
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
