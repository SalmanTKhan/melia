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

[TrackScript("HUEVILLAGE_58_2_SQ03_TRACK")]
public class HUEVILLAGE582SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_2_SQ03_TRACK");
		//SetMap("f_huevillage_58_2");
		//CenterPos(853.56,0.65,252.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400742, "", "f_huevillage_58_2", 814.66, 0.65, 606.78, 106.1364);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147414, "", "f_huevillage_58_2", 859, 0, 205, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400741, "", "f_huevillage_58_2", 814.656, 0.6496, 606.7751, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(861.5775f, 0.6496f, 232.138f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_smoke001", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire003_violet", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire003_violet", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire003_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke029_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_violet", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_violet", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire003_violet", "BOT");
				break;
			case 39:
				//TRACK_SETTENDENCY();
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
