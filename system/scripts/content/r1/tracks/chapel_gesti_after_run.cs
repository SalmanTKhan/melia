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

[TrackScript("CHAPEL_GESTI_AFTER_RUN")]
public class CHAPELGESTIAFTERRUN : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPEL_GESTI_AFTER_RUN");
		//SetMap("d_chapel_57_7");
		//CenterPos(21.27,48.56,-100.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57055, "", "d_chapel_57_7", -26.6673, 48.7113, -138.7382, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 152003, "UnvisibleName", "d_chapel_57_7", 207.33, 164.8635, -582.4594, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147352, "", "d_chapel_57_7", 133.9402, 164.8635, -576.6935, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147390, "", "d_chapel_57_7", 107.7591, 164.8635, -579.8735, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147373, "", "d_chapel_57_7", 114, 164, -611, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147382, "", "d_chapel_57_7", -164.9418, 35.91732, -6.936089, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_chapel_57_7", -173.7959, 35.91732, -1.946014, 57.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(37.53703f, 48.55575f, -157.1883f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_spread_out028_dark_fire", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_warrior_leapattack_shot_ground", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_warrior_leapattack_shot_ground", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_explosion011_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_warrior_leapattack_shot_ground", "BOT", 0);
				break;
			case 57:
				await track.Dialog.Msg("CHAPLE577_MQ_09_FIN");
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("F_spin030_fire", "BOT", 0);
				break;
			case 66:
				character.AddSessionObject(PropertyName.CHAPLE577_MQ_09, 1);
				break;
			case 75:
				break;
			case 76:
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 83:
				break;
			case 90:
				await track.Dialog.Msg("CHAPLE577_MQ_09_FIN_BLACK_MAN");
				break;
			case 92:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 103:
				//DRT_FUNC_ACT("CHAPLE577_MQ_09_EVT_BGM");
				break;
			case 104:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
