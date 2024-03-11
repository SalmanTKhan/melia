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

[TrackScript("CASTLE93_MAIN05_TRACK")]
public class CASTLE93MAIN05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE93_MAIN05_TRACK");
		//SetMap("f_castle_93");
		//CenterPos(212.38,291.67,-522.68);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(212.3763f, 291.6668f, -522.6758f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156116, "Schaffenstar", "f_castle_93", 190, 291, -551, 3.870968);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155163, "", "f_castle_93", 267, 291, -188, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156128, "", "f_castle_93", 395, 291, -193, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156122, "", "f_castle_93", 441, 291, -499, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156124, "", "f_castle_93", 143, 291, -487, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156126, "", "f_castle_93", 154, 291, -389, 0.4761905);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156129, "", "f_castle_93", 167, 291, -229, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147468, "", "f_castle_93", 316, 291, -348, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 156129, "", "f_castle_93", 492.4859, 291.6668, -228.2076, 59.23077);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 156125, "", "f_castle_93", 536.9016, 291.6668, -232.5416, 54.375);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 156127, "", "f_castle_93", 534.7318, 291.6668, -271.3301, 55.9375);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 156130, "", "f_castle_93", 508.4556, 291.6668, -194.0185, 59.6875);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20042, "", "f_castle_93", 218.5, 291.67, -489.76, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20042, "", "f_castle_93", 227.07, 291.67, -548.98, 1.666667);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20042, "", "f_castle_93", 194.5, 291.67, -497.21, 32.5);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20042, "", "f_castle_93", 244.24, 291.67, -513.88, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", 195.7333, 291.6668, -494.9559, 0.390625);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", 220.1196, 291.6668, -491.2315, 1890);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", 250.713, 291.6668, -514.5055, 1930);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", 233.6508, 291.6668, -550.4911, 1830);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 85:
				break;
			case 88:
				//DRT_ACTOR_PLAY_EFT("I_smoke011_smoke2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke011_smoke2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke011_smoke2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke011_smoke2", "MID", 0);
				break;
			case 91:
				//DisableBornAni();
				//DisableBornAni();
				//DisableBornAni();
				//DisableBornAni();
				break;
			case 134:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
