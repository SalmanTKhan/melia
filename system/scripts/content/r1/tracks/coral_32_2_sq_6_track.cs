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

[TrackScript("CORAL_32_2_SQ_6_TRACK")]
public class CORAL322SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_32_2_SQ_6_TRACK");
		//SetMap("f_coral_32_2");
		//CenterPos(-80.72,-56.25,1278.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-68.88226f, -56.24866f, 1266.255f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151024, "", "f_coral_32_2", -200.54, -61.07, 1448.77, 2.738095);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155044, "", "f_coral_32_2", -85.46698, -37.80857, 1194.492, 86.66666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156007, "", "f_coral_32_2", -47.23515, -28.30971, 1164.636, 79);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47505, "", "f_coral_32_2", -27.55054, -56.24866, 1549.577, 26.13636);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20044, "", "f_coral_32_2", -64.65283, -29.70589, 1169.658, 0);
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
			case 1:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the Crabil that is occupying the altar", 5);
				//DRT_ADDBUFF("CORAL_32_2_SQ_6_BUFF", 1, 0, 0, 1);
				break;
			case 24:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 27:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
