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

[TrackScript("SIAULIAI_35_1_SQ_7_TRACK")]
public class SIAULIAI351SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_35_1_SQ_7_TRACK");
		//SetMap("f_siauliai_35_1");
		//CenterPos(46.06,-157.54,913.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(46.06371f, -157.5367f, 913.4235f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156024, "", "f_siauliai_35_1", 13.03893, -157.5367, 952.9973, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect Lucienne until the reaction reagent is finished.", 4);
				break;
			case 4:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("SIAULIAI_35_1_SQ_7_MINI");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
