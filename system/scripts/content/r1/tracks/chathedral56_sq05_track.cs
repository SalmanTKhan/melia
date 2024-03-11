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

[TrackScript("CHATHEDRAL56_SQ05_TRACK")]
public class CHATHEDRAL56SQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL56_SQ05_TRACK");
		//SetMap("d_cathedral_56");
		//CenterPos(-1565.65,0.50,-714.39);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1565.652f, 0.4988f, -714.3873f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47124, "", "d_cathedral_56", -1567.256, 0.4988, -740.7457, 4.166667);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57370, "", "d_cathedral_56", -1540.454, 0.4988, -116.4344, 20.33333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57370, "", "d_cathedral_56", -1594.736, 0.4988, -62.7153, 33.4375);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57370, "", "d_cathedral_56", -1505.941, 0.4988, -59.46452, 37.1875);
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
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground158_light_green", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground135", "BOT");
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_!", "Protect the magic circle from the demons!", 3);
				break;
			case 32:
				CreateBattleBoxInLayer(character, track);
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("CHATHEDRAL56_SQ05_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
