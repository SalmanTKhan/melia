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

[TrackScript("EP14_1_FCASTLE5_MQ_2_TRACK")]
public class EP141FCASTLE5MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_2_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(1457.23,135.00,45.40);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1455.265f, 134.9981f, 45.60889f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150262, "", "ep14_1_f_castle_5", 1339.927, 134.998, -10.80469, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150258, "", "ep14_1_f_castle_5", 1343.125, 134.9983, 104.4736, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", 1687.793, 135.0043, -452.9182, 2.416667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", 1685.216, 135.0012, -21.3169, 2.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "", "ep14_1_f_castle_5", 1680.665, 134.9997, 407.3839, 2.333333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150287, "", "ep14_1_f_castle_5", 1432.192, 134.9982, -110.1375, 29.64286);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154120, "", "ep14_1_f_castle_5", 1405.366, 134.9982, -144.0468, 26.77419);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150289, "", "ep14_1_f_castle_5", 1464.334, 134.998, -7.171581, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150289, "", "ep14_1_f_castle_5", 1465.91, 134.9983, 102.8192, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_ground071_smoke3", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_ground071_smoke3", "BOT", 0);
				break;
			case 40:
				break;
			case 42:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 49:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 56:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERSHOW");
				break;
			case 124:
				await track.Dialog.Msg("EP14_1_FCASTLE5_MQ_2_TRACK_DLG1");
				break;
			case 129:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE5_MQ_2_TRACK_SOLDIERCLEAN");
				break;
			case 133:
				character.AddonMessage("NOTICE_Dm_scroll", "Attack the left front.", 3);
				break;
			case 135:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
