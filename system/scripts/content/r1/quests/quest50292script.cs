//--- Melia Script -----------------------------------------------------------
// Research For Success
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(50292)]
public class Quest50292Script : QuestScript
{
	protected override void Load()
	{
		SetId(50292);
		SetName("Research For Success");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_10"));

		AddReward(new ItemReward("Gacha_H_006", 1));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_351_HQ1_start1", "SIAULIAI_351_HQ1", "How can I help you?", "I'll do it later"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_351_HQ1_agree1");
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

		if (character.Inventory.HasItem("SIAULIAI_351_HIDDENQ1_ITEM1", 6) && character.Inventory.HasItem("SIAULIAI_351_HIDDENQ1_ITEM2", 6))
		{
			character.Inventory.RemoveItem("SIAULIAI_351_HIDDENQ1_ITEM1", 6);
			character.Inventory.RemoveItem("SIAULIAI_351_HIDDENQ1_ITEM2", 6);
			await dialog.Msg("SIAULIAI_351_HQ1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

