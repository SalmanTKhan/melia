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

[TrackScript("JOB_SAPPER2_1_TRACK")]
public class JOBSAPPER21TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_SAPPER2_1_TRACK");
		//SetMap("f_siauliai_west");
		//CenterPos(162.25,322.87,416.30);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 262.4509, 322.8697, 256.8275, 28.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 45;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 308.707, 322.8697, 304.3216, 21.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 45;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 192.7031, 322.8697, 216.0141, 19.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 45;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 290.1358, 322.8697, 222.7822, 9);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 45;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 249.5732, 322.8697, 201.9165, 16.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 45;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47528, "", "f_siauliai_west", 301.4586, 322.8697, 260.8583, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 45;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147392, "UnvisibleName", "f_siauliai_west", 243.1962, 322.8697, 330.6442, 19.58333);
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
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_ground068_smoke", "BOT", 0);
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
