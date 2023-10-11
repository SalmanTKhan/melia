//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (14)
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard General Heosha.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(63118)]
public class Quest63118Script : QuestScript
{
	protected override void Load()
	{
		SetId(63118);
		SetName("Revelator of Moroth (14)");
		SetDescription("Talk to Guard General Heosha");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_13"));

		AddReward(new ItemReward("TP_jexpCard_UpRank5", 1));
		AddReward(new ItemReward("Jumping_expCard_450Lv_notrade", 1));
		AddReward(new ItemReward("EscapeStone_Klaipeda", 1));
		AddReward(new ItemReward("select_Growth_Equip", 1));

		AddDialogHook("EP14_HEOSHAA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_MULIA_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_14_1", "EP14_3LINE_TUTO_MQ_14", "I'm ready to leave", "I'm not ready yet"))
		{
			case 1:
				// Func/EP14_3LINE_TUTO_MQ_14_RUN;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP14_3LINE_TUTO_MQ_14_3");
		await dialog.Msg("FadeOutIN/2000");
		await dialog.Msg("NoneHideNPC/EP14_MULIA_NPC_3/0/0");
		// Func/EP14_3LINE_TUTO_MQ_14_RUN_END;
		dialog.UnHideNPC("EP14_F_CORAL_RAID_1_NPC_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

