//--- Melia Script -----------------------------------------------------------
// Educational Materials of the Kedora Merchant Alliance (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Margellius.
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

[QuestScript(41680)]
public class Quest41680Script : QuestScript
{
	protected override void Load()
	{
		SetId(41680);
		SetName("Educational Materials of the Kedora Merchant Alliance (1)");
		SetDescription("Talk to Margellius");

		AddPrerequisite(new LevelPrerequisite(110));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_48_SQ_010"));

		AddObjective("collect0", "Collect 17 Kedora Merchant Alliance Educational Material(s)", new CollectItemObjective("PILGRIM_48_SQ_080_ITEM_1", 17));
		AddDrop("PILGRIM_48_SQ_080_ITEM_1", 8f, 58140, 58142);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_MARCELIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_MARCELIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_080_ST", "PILGRIM_48_SQ_080", "I will find it", "That's going to be too difficult"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_080_AC");
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

		if (character.Inventory.HasItem("PILGRIM_48_SQ_080_ITEM_1", 17))
		{
			character.Inventory.RemoveItem("PILGRIM_48_SQ_080_ITEM_1", 17);
			await dialog.Msg("PILGRIM_48_SQ_080_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

