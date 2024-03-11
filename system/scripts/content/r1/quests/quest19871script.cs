//--- Melia Script -----------------------------------------------------------
// Avoiding Infatuation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Theophilis.
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

[QuestScript(19871)]
public class Quest19871Script : QuestScript
{
	protected override void Load()
	{
		SetId(19871);
		SetName("Avoiding Infatuation (1)");
		SetDescription("Talk to Pilgrim Theophilis");

		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("collect0", "Collect 1 Theophilis' Bag", new CollectItemObjective("PILGRIM52_SQ_011_ITEM", 1));
		AddDrop("PILGRIM52_SQ_011_ITEM", 10f, 57282, 57279, 57647);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_011_ST", "PILGRIM52_SQ_011", "I will consume the medicine", "Reject it since it seems suspicious"))
		{
			case 1:
				await dialog.Msg("PILGRIM52_SQ_011_AC");
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

		if (character.Inventory.HasItem("PILGRIM52_SQ_011_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM52_SQ_011_ITEM", 1);
			await dialog.Msg("PILGRIM52_SQ_011_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

