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

[TrackScript("TABLELAND_73_SQ3_TRACK")]
public class TABLELAND73SQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_73_SQ3_TRACK");
		//SetMap("f_tableland_73");
		//CenterPos(-1042.62,448.94,-1199.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153155, "", "f_tableland_73", -1063, 448.93, -1180.61, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153042, "UnvisibleName", "f_tableland_73", -1076.66, 448.94, -1250.36, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153042, "UnvisibleName", "f_tableland_73", -1047.37, 448.93, -1105.48, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153042, "UnvisibleName", "f_tableland_73", -1135.57, 448.93, -1162.7, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153042, "UnvisibleName", "f_tableland_73", -1000.4, 448.93, -1187.85, 0);
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
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_light082_line_red", "arrow_blow", "SLOW", 90, 1, 0, 5, 10, 0);
				break;
			case 9:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
