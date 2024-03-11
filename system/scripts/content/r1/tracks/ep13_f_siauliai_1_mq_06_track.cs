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

[TrackScript("EP13_F_SIAULIAI_1_MQ_06_TRACK")]
public class EP13FSIAULIAI1MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_MQ_06_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(-1634.05,65.41,-1339.84);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1634.436f, 65.4132f, -1338.578f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150243, "", "ep13_f_siauliai_1", -1684.326, 65.4132, -1332.684, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59594, "", "ep13_f_siauliai_1", -1771.893, 65.4132, -1324.087, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", -1622.859, 65.4132, -1409.61, 14.09091);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", -1609.777, 65.4132, -1277.437, 9.545454);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", -1687.486, 65.4132, -1393.691, 33.33334);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", -1677.831, 65.4132, -1263.778, 28.88889);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59579, "", "ep13_f_siauliai_1", -1559.657, 65.4132, -1347.727, 35);
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
			case 15:
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_ground059_fire2", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_smoke168_darkpuple", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke178_puple", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_circle029_ground", "BOT", 0);
				break;
			case 47:
				break;
			case 49:
				break;
			case 54:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_1_MQ_06_DLG_T1", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
