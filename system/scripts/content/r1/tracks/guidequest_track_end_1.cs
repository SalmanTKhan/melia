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

[TrackScript("GuideQuest_Track_End_1")]
public class GuideQuestTrackEnd1 : TrackScript
{
	protected override void Load()
	{
		SetId("GuideQuest_Track_End_1");
		//SetMap("c_klaipe_castle");
		//CenterPos(1686.67,-127.02,-15.83);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		return Array.Empty<IActor>();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 16:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_1");
				break;
			case 19:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_2");
				break;
			case 23:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_3");
				break;
			case 29:
				//DRT_FUNC_ACT("SCR_GuideQuest_Track_DIR_1");
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_4");
				break;
			case 35:
				//DRT_FUNC_ACT("SCR_GuideQuest_Track_DIR_2");
				//DRT_ADDBUFF("Stop_buff", 1, 0, 0, 1);
				//DRT_ADDBUFF("Stop_buff", 1, 0, 0, 1);
				break;
			case 44:
				//DRT_ADDBUFF("Stop_buff", 1, 0, 0, 1);
				//DRT_ADDBUFF("Stop_buff", 1, 0, 0, 1);
				//DRT_ADDBUFF("Stop_buff", 1, 0, 0, 1);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke186_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 74:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_5");
				break;
			case 108:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_6");
				break;
			case 110:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_7");
				break;
			case 129:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark_drop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke186_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground116_circle_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion078_dark", "BOT");
				break;
			case 131:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_8");
				break;
			case 133:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_9");
				break;
			case 140:
				await track.Dialog.Msg("GuideQuest_Track_End_1_DLG_10");
				break;
			case 142:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder010_light_dark", "BOT");
				break;
			case 148:
				//DRT_FUNC_ACT("SCR_GuideQuest_Track_DIR_3");
				//DRT_RUN_FUNCTION("SCR_GuideQuest_Track_BuffCheck_pc");
				break;
			case 149:
				character.AddSessionObject(PropertyName.EP14_3LINE_TUTO_MQ_10, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
