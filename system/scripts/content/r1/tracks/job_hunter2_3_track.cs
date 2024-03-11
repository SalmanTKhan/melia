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

[TrackScript("JOB_HUNTER2_3_TRACK")]
public class JOBHUNTER23TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_HUNTER2_3_TRACK");
		//SetMap("f_siauliai_out");
		//CenterPos(44.23,153.70,-157.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 10043, "Boulder", "f_siauliai_out", 159.0274, 150.1628, -67.17754, 0, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10043, "Boulder", "f_siauliai_out", 213.8377, 150.317, -157.0855, 0, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10043, "Boulder", "f_siauliai_out", 126.253, 151.4445, -239.2974, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 26.96248, 153.703, -53.5655, 16.25);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 45;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 108.7856, 153.703, -20.63264, 121.6667);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 45;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 71.89813, 153.703, -44.73512, 35.71429);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 45;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 118.1488, 153.703, -131.9829, 32.14286);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 45;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 56.96442, 153.703, -183.7819, 18.57143);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 45;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 192.7614, 153.703, -201.6457, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 45;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 184.7751, 153.703, -103.9233, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 45;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57024, "", "f_siauliai_out", 53.18935, 153.703, -109.6925, 20.71429);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.Level = 45;
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
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
