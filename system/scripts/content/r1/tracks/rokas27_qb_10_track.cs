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

[TrackScript("ROKAS27_QB_10_TRACK")]
public class ROKAS27QB10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS27_QB_10_TRACK");
		//SetMap("f_rokas_27");
		//CenterPos(1730.70,1243.52,-30.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1784.479f, 1227.67f, -99.10748f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152002, "UnvisibleName", "f_rokas_27", 1860.138, 1227.67, -374.4985, 63.125);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41379, "", "f_rokas_27", 1849.326, 1227.67, -273.8232, 73.125);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 152001, "UnvisibleName", "f_rokas_27", 1697.418, 1246.491, -44.79739, 77.22222);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "f_rokas_27", 1845.651, 1227.67, -262.5773, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				break;
			case 15:
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion032_red", "MID");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_shot_smoke", "BOT");
				break;
			case 24:
				//SetFixAnim("down");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_green", "BOT");
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
