//--- Melia Script -----------------------------------------------------------
// Greed of a Merchant (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Greedy Merchant.
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

[QuestScript(91192)]
public class Quest91192Script : QuestScript
{
	protected override void Load()
	{
		SetId(91192);
		SetName("Greed of a Merchant (1)");
		SetDescription("Talk to the Greedy Merchant");

		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(4200000000, 4200000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY2_SQ1_DLG1", "EP15_1_ABBEY2_SQ1", "I'll help you.", "I'm too busy find someone else."))
		{
			case 1:
				await dialog.Msg("EP15_1_ABBEY2_SQ1_DLG2");
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

		if (character.Inventory.HasItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 20))
		{
			character.Inventory.RemoveItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 20);
			await dialog.Msg("EP15_1_ABBEY2_SQ1_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

