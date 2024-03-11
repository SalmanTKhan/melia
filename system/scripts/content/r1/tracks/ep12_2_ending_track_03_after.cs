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

[TrackScript("EP12_2_ENDING_TRACK_03_AFTER")]
public class EP122ENDINGTRACK03AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_ENDING_TRACK_03_AFTER");
		//SetMap("d_dcapital_108");
		//CenterPos(474.42,23.86,2482.05);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(475.0504f, 23.85547f, 2480.667f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150238, "Mulia", "d_dcapital_108", 473.2092, 23.85547, 2504.834, 0.2083333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47236, "Laima", "d_dcapital_108", 475.1405, 23.85547, 2530.521, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150238, "", "d_dcapital_108", 473.0172, 23.85547, 2504.882, 5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "d_dcapital_108", 474.6874, 23.85547, 2504.085, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ18_DLG_27", 3);
				break;
			case 25:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ18_DLG_28");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				break;
			case 54:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_smoke181_white", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_light066_yellow_loop2", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 88:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke_giltineraid_02_downsmoke_loop", "BOT");
				break;
			case 101:
				//DRT_ACTOR_PLAY_EFT("F_smoke_giltineraid_02_downsmoke", "BOT", 0);
				break;
			case 129:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("SCR_EP12_2_STORY_AFTER");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
