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

[TrackScript("DCAPITAL107_SQ_8_TRACK")]
public class DCAPITAL107SQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL107_SQ_8_TRACK");
		//SetMap("f_dcapital_107");
		//CenterPos(311.73,39.79,-1201.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57578, "", "f_dcapital_107", 291.8559, 39.79394, -1214.537, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(321.4603f, 39.79393f, -1227.272f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 154016, "", "f_dcapital_107", 299.8351, 39.79394, -1163.944, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 103052, "", "f_dcapital_107", 350.3946, 39.79393, -858.5945, 123.5714);
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
			case 10:
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_cylinder009_light_ice", "BOT", 0);
				break;
			case 31:
				break;
			case 38:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "F_hit011_puple_light", "arrow_blow", "SLOW", 150, 1, 0, 5, 10, 0);
				break;
			case 43:
				//TRACK_SETTENDENCY();
				break;
			case 44:
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				//SetFixAnim("event_sit_idle");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
