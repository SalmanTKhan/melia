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

[TrackScript("EP12_2_F_CASTLE_101_MQ06_TRACK_01")]
public class EP122FCASTLE101MQ06TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ06_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(-152.70,52.93,-680.61);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-153.1427f, 52.92822f, -679.6096f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "f_castle_101", 117.8619, 52.92822, -522.1024, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "f_castle_101", -111.7566, 52.92822, -756.3589, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150230, "", "f_castle_101", -192.2616, 52.92822, -706.0736, 2.61194);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47269, "", "f_castle_101", 117.2889, 52.92822, -523.0613, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59509, "", "f_castle_101", 114.7216, 52.92822, -519.3476, 26.66667);
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
			case 10:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("I_smoke027_spread_out", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_violet", "TOP", 0);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_firetower_teleport", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_2");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_violet_rize", "BOT", 0);
				break;
			case 75:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_3");
				break;
			case 79:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
