//--- Melia Script -----------------------------------------------------------
// Erecting Tombstones (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Antanas.
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

[QuestScript(41700)]
public class Quest41700Script : QuestScript
{
	protected override void Load()
	{
		SetId(41700);
		SetName("Erecting Tombstones (1)");
		SetDescription("Talk to Antanas");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("collect0", "Collect 9 Lime Powder(s)", new CollectItemObjective("PILGRIM_49_SQ_010_ITEM_2", 9));
		AddDrop("PILGRIM_49_SQ_010_ITEM_2", 10f, 58131, 58132, 58133);

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_ANTANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_010_ST", "PILGRIM_49_SQ_010", "I'll help you", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_010_AC");
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

		if (character.Inventory.HasItem("PILGRIM_49_SQ_010_ITEM_2", 9))
		{
			character.Inventory.RemoveItem("PILGRIM_49_SQ_010_ITEM_2", 9);
			await dialog.Msg("PILGRIM_49_SQ_010_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

