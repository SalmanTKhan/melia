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

[TrackScript("JOB_HUNTER2_1_TRACK")]
public class JOBHUNTER21TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_HUNTER2_1_TRACK");
		//SetMap("f_siauliai_out");
		//CenterPos(1896.73,147.35,260.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103001, "", "f_siauliai_out", 1891.735, 147.3516, 233.3133, 19.10256);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 45;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 11125, "", "f_siauliai_out", 1676.986, 147.3516, 137.3532, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 40;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 11125, "", "f_siauliai_out", 1728.508, 147.3516, 196.7788, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 40;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 11125, "", "f_siauliai_out", 2055.151, 147.3516, 315.9732, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 40;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 11125, "", "f_siauliai_out", 2115.844, 147.3516, 280.0655, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 40;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 11160, "", "f_siauliai_out", 1761.833, 147.3516, 256.768, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 40;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 11160, "", "f_siauliai_out", 1974.067, 147.3516, 334.2063, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 40;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(50);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
