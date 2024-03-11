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

[TrackScript("CORAL_32_1_SQ_8_TRACK")]
public class CORAL321SQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_32_1_SQ_8_TRACK");
		//SetMap("None");
		//CenterPos(1238.14,226.10,1047.64);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1302.185f, 226.1049f, 1205.783f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155003, "UnvisibleName", "None", 1312.917, 226.1049, 1172.633, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41316, "", "None", 1191.767, 226.1049, 956.64, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41316, "", "None", 1296.086, 226.1049, 936.6727, 0);
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
			case 7:
				break;
			case 8:
				character.AddonMessage("NOTICE_Dm_!", "Monsters are gathering to the smell of the bag!", 5);
				break;
			case 9:
				//TRACK_SETTENDENCY();
				break;
			case 10:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//DRT_PLAY_MGAME("CORAL_32_1_SQ_8_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
