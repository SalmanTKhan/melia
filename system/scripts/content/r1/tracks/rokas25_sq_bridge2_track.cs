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

[TrackScript("ROKAS25_SQ_BRIDGE2_TRACK")]
public class ROKAS25SQBRIDGE2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS25_SQ_BRIDGE2_TRACK");
		//SetMap("f_rokas_25");
		//CenterPos(124.47,267.94,708.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20138, "", "f_rokas_25", 189.2569, 267.9441, 763.2182, 51.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 40064, "Molding Pot", "f_rokas_25", 251.4649, 267.9441, 800.5751, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 40064, "Molding Pot", "f_rokas_25", 205, 267, 805, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20117, "", "f_rokas_25", 41.05011, 267.9441, 520.0391, 91);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57100, "", "f_rokas_25", -111.9695, 267.9541, 531.3784, 38.75);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(195.3004f, 267.9441f, 734.2671f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 20049, "", "f_rokas_25", 408.9801, 267.9441, 772.34, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20049, "", "f_rokas_25", 502.9886, 268.1596, 651.293, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 26:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 32:
				//TRACK_SETTENDENCY();
				break;
			case 34:
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Yonazolem that Toby brought along!", 3);
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
