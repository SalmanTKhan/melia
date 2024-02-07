using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP14_1_FCASTLE2_MQ_1_TRACK")]
public class EP141FCASTLE2MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE2_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_2");
		//CenterPos(1914.78,1.22,568.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1897.267f, 1.219482f, 563.0673f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147326, "", "ep14_1_f_castle_2", 1949.709, 1.219482, 536.7458, 84.28571, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 470;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_2", 1892.678, 1.219482, 984.5766, 15.35714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150219, "", "ep14_1_f_castle_2", 1908.641, 1.219482, 938.4766, 14.64286);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1854.816, 1.219482, 876.7482, 16.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1963.991, 1.219482, 843.7989, 21);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1939.921, 1.219482, 373.433, 67);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1969.668, 1.219482, 409.57, 72.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1898.421, 1.219482, 429.41, 66.5);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1989.3, 1.219482, 355.473, 69);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59695, "", "ep14_1_f_castle_2", 1887.034, 1.219482, 375.5473, 71.5);
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
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "BOT", 0);
				break;
			case 31:
				break;
			case 44:
				//DRT_PLAY_MGAME("EP14_1_FCASTLE2_MQ_1_MGAME");
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_RUN_FUNCTION("SCR_EP14_1_TRACKNPC_NODAMAGE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
