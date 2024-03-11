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

[TrackScript("CASTLE102_MQ_03_TRACK")]
public class CASTLE102MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE102_MQ_03_TRACK");
		//SetMap("f_castle_102");
		//CenterPos(-1074.39,52.90,313.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150215, "", "f_castle_102", -1090.85, 52.90469, 669.7462, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1074.394f, 52.90469f, 313.1051f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_castle_102", -1090.923, 52.90469, 664.6866, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 41:
				await track.Dialog.Msg("CASTLE102_MQ_03_DLG02");
				break;
			case 44:
				//DisableBornAni();
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere002_blue_loop", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_warrior_PainBarrier_buff2_swordman01_3", "BOT", 0);
				break;
			case 49:
				await track.Dialog.Msg("CASTLE102_MQ_03_DLG03");
				break;
			case 53:
				//DRT_FUNC_ACT("SCR_CASTLE102_QUESTION_01");
				break;
			case 54:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere002_blue_loop", "BOT");
				break;
			case 63:
				//DRT_FUNC_ACT("SCR_CASTLE102_QUESTION_02");
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				break;
			case 65:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere002_blue_loop", "BOT");
				break;
			case 73:
				//DRT_FUNC_ACT("SCR_CASTLE102_QUESTION_03");
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				break;
			case 75:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere002_blue_loop", "BOT");
				break;
			case 84:
				await track.Dialog.Msg("CASTLE102_MQ_03_DLG07");
				break;
			case 94:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
