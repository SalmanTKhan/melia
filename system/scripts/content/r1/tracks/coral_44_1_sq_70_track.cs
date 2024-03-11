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

[TrackScript("CORAL_44_1_SQ_70_TRACK")]
public class CORAL441SQ70TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_1_SQ_70_TRACK");
		//SetMap("f_coral_44_1");
		//CenterPos(-723.00,4.47,-1147.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-809.1703f, 1.673355f, -1125.55f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155044, "", "f_coral_44_1", 1551.51, 20.32962, -222.4828, 115);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151024, "UnvisibleName", "f_coral_44_1", 1580.31, 20.32, -280.51, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_PLAY_MGAME("CORAL_44_1_SQ_70_MINI");
				break;
			case 2:
				//DRT_FUNC_ACT("SCR_CORAL_44_1_SQ_70_NPC_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
