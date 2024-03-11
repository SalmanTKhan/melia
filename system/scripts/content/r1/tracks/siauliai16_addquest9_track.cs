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

[TrackScript("SIAULIAI16_ADDQUEST9_TRACK")]
public class SIAULIAI16ADDQUEST9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI16_ADDQUEST9_TRACK");
		//SetMap("f_siauliai_16");
		//CenterPos(-539.56,74.85,1614.97);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57112, "", "f_siauliai_16", -459.7383, 74.8618, 954.1473, 90.83333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 60;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 400082, "", "f_siauliai_16", -428.0875, 74.8618, 1398.847, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 59;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400081, "", "f_siauliai_16", -612.6555, 74.8618, 1321.706, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 59;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400084, "", "f_siauliai_16", -529.0013, 74.8618, 1279.751, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 59;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 400081, "", "f_siauliai_16", -424.639, 74.8618, 1360.554, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 59;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400082, "", "f_siauliai_16", -446.9417, 74.8618, 1319.759, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 59;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400085, "", "f_siauliai_16", -576.4083, 74.8618, 1210.871, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 59;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				//TRACK_SETTENDENCY();
				break;
			case 24:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
