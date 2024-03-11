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

[TrackScript("M_FLIBRAY_VALDOVAS_1")]
public class MFLIBRAYVALDOVAS1 : TrackScript
{
	protected override void Load()
	{
		SetId("M_FLIBRAY_VALDOVAS_1");
		//SetMap("mission_fantasylibrary_1");
		//CenterPos(-200.72,37.25,734.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-198.9948f, 37.72691f, 732.7977f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 58567, "", "mission_fantasylibrary_1", -582.4919, 14.4972, 682.5551, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58585, "", "mission_fantasylibrary_1", -1024.903, 13.91987, 466.4917, 0);
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
			case 17:
				break;
			case 56:
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground071_fire", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_fantasylibrary_brickfloor_dead", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke126", "BOT");
				break;
			case 65:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground064_fire", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
