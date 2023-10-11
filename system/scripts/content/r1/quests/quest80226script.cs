//--- Melia Script -----------------------------------------------------------
// Treasure Hunting (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Manderson.
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

[QuestScript(80226)]
public class Quest80226Script : QuestScript
{
	protected override void Load()
	{
		SetId(80226);
		SetName("Treasure Hunting (1)");
		SetDescription("Talk to Guard Manderson");

		AddPrerequisite(new LevelPrerequisite(204));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH29_1_SQ_090", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH29_1_SQ_090", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH29_1_SQ_090_select01", "FLASH_29_1_SQ_090", "I will check it", "I don't want to"))
		{
			case 1:
				await dialog.Msg("FLASH29_1_SQ_090_agree01");
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

		if (character.Inventory.HasItem("FLASH29_1_SQ_090_ITEM", 12))
		{
			character.Inventory.RemoveItem("FLASH29_1_SQ_090_ITEM", 12);
			await dialog.Msg("FLASH29_1_SQ_090_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

