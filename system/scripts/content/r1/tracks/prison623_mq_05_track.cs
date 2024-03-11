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

[TrackScript("PRISON623_MQ_05_TRACK")]
public class PRISON623MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON623_MQ_05_TRACK");
		//SetMap("d_prison_62_3");
		//CenterPos(906.97,981.91,380.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(885.3389f, 981.9104f, 381.2605f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156006, "", "d_prison_62_3", 854.6493, 981.9104, 412.9588, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_prison_62_3", 900.803, 981.9104, 451.9311, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_prison_62_3", 930.7638, 997.5414, 674.2582, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 45324, "", "d_prison_62_3", 989.158, 997.5414, 1000.207, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58071, "", "d_prison_62_3", 945.2391, 997.5414, 673.2864, 45.33333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20024, "", "d_prison_62_3", 944.8405, 997.5414, 652.2281, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic009_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion027_blue", "TOP");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_light062", "TOP");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25", "BOT");
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke120_dark", "BOT");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke143_dark_red", "BOT");
				break;
			case 73:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground_loop", "BOT");
				break;
			case 76:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				break;
			case 99:
				await track.Dialog.Msg("PRISON623_MQ_05_TRACK_DLG_1");
				break;
			case 108:
				//DRT_FUNC_ACT("PRISON623_MQ_09_EVT_BGM");
				//SCR_SAME_LAYER_SETPOS_FADEOUT_RUN(-30, 30);
				break;
			case 109:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
