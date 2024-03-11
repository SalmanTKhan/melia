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

[TrackScript("EP15_1_F_ABBEY3_5_2_TRACK")]
public class EP151FABBEY352TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY3_5_2_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(4.56,44.60,931.24);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1.243516f, 46.035f, 903.4691f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep15_1_f_abbey_3", 108.8909, 44.60282, 1494.503, 6.625);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "ep15_1_f_abbey_3", 11.1013, 44.60283, 1459.684, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59776, "", "ep15_1_f_abbey_3", 15.36525, 44.60283, 1453.897, 1.666667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 12.96212, 44.60283, 1457.323, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 11.8412, 44.60283, 1458.631, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 111.6025, 44.60282, 1491.013, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 125.9162, 44.60282, 1462.461, 3);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG4");
				break;
			case 11:
				break;
			case 20:
				break;
			case 34:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG5");
				break;
			case 45:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG6");
				break;
			case 49:
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_5_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
