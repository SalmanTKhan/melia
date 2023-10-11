//--- Melia Script -----------------------------------------------------------
// Mirtinas' Whereabouts (3)
//--- Description -----------------------------------------------------------
// Quest to Meet Goddess Lada at the entrance of Issaugoti Forest.
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

[QuestScript(91054)]
public class Quest91054Script : QuestScript
{
	protected override void Load()
	{
		SetId(91054);
		SetName("Mirtinas' Whereabouts (3)");
		SetDescription("Meet Goddess Lada at the entrance of Issaugoti Forest");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_07"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_4", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA4TO5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_08_DLG1", "EP13_F_SIAULIAI_3_MQ_08", "It's a good idea", "It's not a good iea"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_3_MQ_08_DLG2");
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_LADA_4");
				dialog.UnHideNPC("EP13_GODDESS_LADA4TO5");
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

		await dialog.Msg("EP13_F_SIAULIAI_3_MQ_08_DLG3");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		// Func/SCR_NEXTQUEST_LEVEL_CHECK/EP13_F_SIAULIAI_4_MQ_01;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

