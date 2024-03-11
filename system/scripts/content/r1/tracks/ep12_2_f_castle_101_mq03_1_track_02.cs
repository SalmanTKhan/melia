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

[TrackScript("EP12_2_F_CASTLE_101_MQ03_1_TRACK_02")]
public class EP122FCASTLE101MQ031TRACK02 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ03_1_TRACK_02");
		//SetMap("None");
		//CenterPos(675.41,52.93,-1.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(685.9568f, 52.92822f, -34.21725f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150235, "", "None", 641.7661, 52.92822, 54.83201, 4.772727);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150233, "UnvisibleName", "None", 589.6722, 52.92822, -21.51109, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150233, "UnvisibleName", "None", 676.8557, 52.92822, 58.01707, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150234, "UnvisibleName", "None", 652.306, 52.92822, -2.075882, 8.947369, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150232, "", "None", 580.1592, 52.92822, 67.05676, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150230, "", "None", 578.2062, 52.92822, -70.62921, 7.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150212, "[랑다", "None", 592.268, 52.92822, -90.85965, 6.25);
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
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_cylinder003_smoke_white", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_item_drop_line_loop_white", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_cylinder003_smoke_white", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_cylinder003_smoke_white", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_explosion001_dark_Low", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				break;
			case 39:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ_RANGDAGIRL_START_STONE", 3);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_01");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				break;
			case 49:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_1_DLG_03");
				break;
			case 50:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ03_1_DLG_04");
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
