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

[TrackScript("F_MAPLE_24_2_MQ_11_TRACK_AFTER")]
public class FMAPLE242MQ11TRACKAFTER : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_11_TRACK_AFTER");
		//SetMap("f_maple_24_2");
		//CenterPos(-1298.39,11.09,-561.09);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1298.388f, 11.09299f, -561.089f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154102, "", "f_maple_24_2", -1346.439, 11.09299, -557.82, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154011, "", "f_maple_24_2", -1342.681, 11.09299, -655.9727, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154012, "", "f_maple_24_2", -1322.654, 11.09299, -514.2982, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154013, "", "f_maple_24_2", -1354.256, 11.09299, -608.5292, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57223, "", "f_maple_24_2", -1248.942, 11.09299, -470.71, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147448, "", "f_maple_24_2", -1208.266, 11.09299, -478.6656, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "", "f_maple_24_2", -1244.465, 11.09299, -476.7674, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "", "f_maple_24_2", -1206.267, 11.09299, -479.847, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_AFTER_DLG_01");
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_spin026", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground020", "BOT", 0);
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_spin015", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 12:
				break;
			case 19:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_AFTER_DLG_02");
				break;
			case 20:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_AFTER_DLG_03");
				break;
			case 21:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_AFTER_DLG_04");
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_spin026", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground020", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_spin015", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 42:
				await track.Dialog.Msg("F_MAPLE_242_11_TRACK_AFTER_DLG_05");
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic026_pink_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic026_pink_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic026_pink_line", "BOT", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "BOT", 0);
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
