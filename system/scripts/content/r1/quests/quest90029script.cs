//--- Melia Script -----------------------------------------------------------
// Emergency Treatment
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Elius.
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

[QuestScript(90029)]
public class Quest90029Script : QuestScript
{
	protected override void Load()
	{
		SetId(90029);
		SetName("Emergency Treatment");
		SetDescription("Talk to Refugee Elius");

		AddPrerequisite(new LevelPrerequisite(232));

		AddObjective("collect0", "Collect 8 Greentoshell Shell Fragment(s)", new CollectItemObjective("CORAL_32_1_SQ_10_ITEM1", 8));
		AddObjective("collect1", "Collect 8 Blue Lapasape Moss(s)", new CollectItemObjective("CORAL_32_1_SQ_10_ITEM2", 8));
		AddDrop("CORAL_32_1_SQ_10_ITEM1", 10f, "Greentoshell");
		AddDrop("CORAL_32_1_SQ_10_ITEM2", 10f, "lapasape_mage_blue");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_PEOPLE4", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_PEOPLE4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_10_ST", "CORAL_32_1_SQ_10", "I'll help you", "It's hard"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_10_AG");
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

		if (character.Inventory.HasItem("CORAL_32_1_SQ_10_ITEM1", 8) && character.Inventory.HasItem("CORAL_32_1_SQ_10_ITEM2", 8))
		{
			character.Inventory.RemoveItem("CORAL_32_1_SQ_10_ITEM1", 8);
			character.Inventory.RemoveItem("CORAL_32_1_SQ_10_ITEM2", 8);
			await dialog.Msg("CORAL_32_1_SQ_10_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

