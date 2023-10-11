//--- Melia Script -----------------------------------------------------------
// The Abandoned Chest
//--- Description -----------------------------------------------------------
// Quest to The Abandoned Chest at Klajone Access Road.
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

[QuestScript(19930)]
public class Quest19930Script : QuestScript
{
	protected override void Load()
	{
		SetId(19930);
		SetName("The Abandoned Chest");
		SetDescription("The Abandoned Chest at Klajone Access Road");

		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("collect0", "Collect 1 Old Key", new CollectItemObjective("PILGRIM52_ITEM_16", 1));
		AddDrop("PILGRIM52_ITEM_16", 10f, 57282, 57279, 57647);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("PILGRIM52_ITEM_06", 1));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_BAG", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_BAG", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("PILGRIM52_ITEM_16", 1))
		{
			character.Inventory.RemoveItem("PILGRIM52_ITEM_16", 1);
			await dialog.Msg("PCAin/UNLOCK/0");
			await Task.Delay(100);
			await dialog.Msg("NPCAin/PILGRIM52_BAG/OPEN/1");
			await Task.Delay(4000);
			await dialog.Msg("NPCAin/PILGRIM52_BAG/OPENSTD/1");
			await Task.Delay(1000);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've found an old handkerchief in the chest");
			await Task.Delay(100);
			await dialog.Msg("NPCAin/PILGRIM52_BAG/CLOSE_1/1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

