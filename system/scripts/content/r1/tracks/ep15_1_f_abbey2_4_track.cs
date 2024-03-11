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

[TrackScript("EP15_1_F_ABBEY2_4_TRACK")]
public class EP151FABBEY24TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_4_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(-1363.63,74.90,1547.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1322.826f, 74.9019f, 1535.23f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 160144, "", "ep15_1_f_abbey_2", -1291.943, 74.9019, 1567.827, 63.57143);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "ep15_1_f_abbey_2", -1369.707, 74.9019, 1501.084, 27.14286);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 160145, "", "ep15_1_f_abbey_2", -1525.485, 74.90192, 1594.463, 4.111111);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150283, "", "ep15_1_f_abbey_2", -1443.557, 74.9019, 1395.02, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59777, "", "ep15_1_f_abbey_2", -1027.992, 167.0494, 1200.484, 132.7273);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59777, "", "ep15_1_f_abbey_2", -959.1742, 171.9146, 1202.938, 88.84616);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59780, "", "ep15_1_f_abbey_2", -1141.455, 95.33152, 1384.22, 125.9091);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59780, "", "ep15_1_f_abbey_2", -1036.369, 128.309, 1322.22, 107.6667);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59780, "", "ep15_1_f_abbey_2", -990.0451, 145.1066, 1284.083, 90.33334);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59777, "", "ep15_1_f_abbey_2", -956.6716, 196.3911, 1119.391, 83.46154);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 59:
				break;
			case 60:
				break;
			case 62:
				break;
			case 63:
				break;
			case 67:
				break;
			case 89:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY2_4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
