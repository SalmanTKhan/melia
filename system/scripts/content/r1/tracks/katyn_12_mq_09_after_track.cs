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

[TrackScript("KATYN_12_MQ_09_AFTER_TRACK")]
public class KATYN12MQ09AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_12_MQ_09_AFTER_TRACK");
		//SetMap("f_katyn_12");
		//CenterPos(1990.11,250.80,140.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151065, "", "f_katyn_12", 1941.514, 250.5592, 183.774, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151064, "", "f_katyn_12", 1951.08, 250.7593, 150.6648, 17);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1995.768f, 251.1906f, 49.70882f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "f_katyn_12", 1943.59, 250.5592, 185.5092, 0);
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
			case 9:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red", "MID");
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_Proliferation_shot_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke023_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke138_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_AttributeChange_ground", "BOT");
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("E_soul", "BOT", 0);
				break;
			case 78:
				character.AddonMessage("NOTICE_Dm_Clear", "All the souls have been freed!", 5);
				break;
			case 79:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
