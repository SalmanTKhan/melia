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

[TrackScript("HUEVILLAGE_58_3_SQ02_TRACK")]
public class HUEVILLAGE583SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_3_SQ02_TRACK");
		//SetMap("f_huevillage_58_3");
		//CenterPos(524.06,-86.71,483.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47318, "", "f_huevillage_58_3", 439.4214, -86.70744, 207.0346, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147412, "", "f_huevillage_58_3", 498, -86, 512, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(503.5803f, -86.7076f, 496.0392f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_huevillage_58_3", 439.42, -86.71, 207.03, 0);
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
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_water008##6", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_water008##5", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_water008##5", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_water008##5", "BOT");
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
