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

[TrackScript("PILGRIM51_SQ_3_TRACK")]
public class PILGRIM51SQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM51_SQ_3_TRACK");
		//SetMap("None");
		//CenterPos(-972.57,548.29,-998.55);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 40120, "", "None", -974.02, 548.29, -937.98, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57419, "", "None", -970.3636, 548.2935, -943.31, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-987.1127f, 548.2935f, -1026.377f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 41353, "", "None", -1160.5, 548.2935, -941.111, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_ADD3_smoke_blue", "BOT");
				break;
			case 3:
				break;
			case 17:
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
