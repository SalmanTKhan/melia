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

[TrackScript("SIAU16_MQ_06_TRACK")]
public class SIAU16MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU16_MQ_06_TRACK");
		//SetMap("f_siauliai_16");
		//CenterPos(2026.94,25.35,346.24);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2041.963f, 25.3504f, 318.7844f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151086, "", "f_siauliai_16", 2024.924, 25.3504, 331.6914, 15.37037);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151081, "Settler", "f_siauliai_16", 2012.455, 25.3504, 298.2903, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151092, "Settler", "f_siauliai_16", 2002.776, 25.3504, 273.6935, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20062, "Settler", "f_siauliai_16", 1990.503, 25.3504, 247.6499, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57993, "", "f_siauliai_16", 2013.319, 25.3504, 791.1069, 1610);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				break;
			case 49:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "Protect the people from the Poata!", 3);
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
