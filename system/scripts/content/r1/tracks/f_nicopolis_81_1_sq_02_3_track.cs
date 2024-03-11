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

[TrackScript("F_NICOPOLIS_81_1_SQ_02_3_TRACK")]
public class FNICOPOLIS811SQ023TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_1_SQ_02_3_TRACK");
		//SetMap("f_nicopolis_81_1");
		//CenterPos(-234.39,135.77,-1108.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-234.3861f, 135.7722f, -1108.634f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151045, "UnvisibleName", "f_nicopolis_81_1", -223.48, 135.77, -1097.69, 53.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151050, "Device", "f_nicopolis_81_1", -129.05, 135.77, -1045.64, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151050, "Device", "f_nicopolis_81_1", -187.65, 135.77, -1202.06, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151050, "Device", "f_nicopolis_81_1", -310.4597, 135.7722, -1133.904, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151050, "Device", "f_nicopolis_81_1", -271.3, 135.77, -993.67, 0);
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
			case 7:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				break;
			case 8:
				character.AddonMessage("NOTICE_Dm_scroll", "Using the Magic Block activated nearby defensive devices.{nl}Deactivate them and use the Magic Block on the sculptures.", 7);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
