//--- Melia Script -----------------------------------------------------------
// Lost Symbol (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kestas who looks very unstable.
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

[QuestScript(41740)]
public class Quest41740Script : QuestScript
{
	protected override void Load()
	{
		SetId(41740);
		SetName("Lost Symbol (1)");
		SetDescription("Talk with Kestas who looks very unstable");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("collect0", "Collect 1 Nestos' Sign", new CollectItemObjective("PILGRIM_49_SQ_050_ITEM_1", 1));
		AddDrop("PILGRIM_49_SQ_050_ITEM_1", 1f, 58131, 58132, 58133);

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_KESTAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_KESTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_050_ST", "PILGRIM_49_SQ_050", "What is it? ", "Ignore and just go your way"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_050_AC");
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

		if (character.Inventory.HasItem("PILGRIM_49_SQ_050_ITEM_1", 1))
		{
			character.Inventory.RemoveItem("PILGRIM_49_SQ_050_ITEM_1", 1);
			await dialog.Msg("PILGRIM_49_SQ_050_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

