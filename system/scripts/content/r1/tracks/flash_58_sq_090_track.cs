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

[TrackScript("FLASH_58_SQ_090_TRACK")]
public class FLASH58SQ090TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_58_SQ_090_TRACK");
		//SetMap("f_flash_58");
		//CenterPos(-238.01,407.60,-1013.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156023, "", "f_flash_58", -231.97, 407.6, -954.78, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-249.1669f, 407.5999f, -1018.743f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20025, "", "f_flash_58", -231.97, 407.6, -954.78, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_flash_58", -231.97, 407.6, -954.78, 0);
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
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire038_loop", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground093_dark", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke014_firesteam_dead", "BOT");
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(300);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
