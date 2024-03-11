//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (6)
//--- Description -----------------------------------------------------------
// Quest to Repair the detector at Skida Bastion.
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

[QuestScript(40830)]
public class Quest40830Script : QuestScript
{
	protected override void Load()
	{
		SetId(40830);
		SetName("Check the Detector's Functionality (6)");
		SetDescription("Repair the detector at Skida Bastion");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_050"));

		AddObjective("collect0", "Collect 1 Braid", new CollectItemObjective("FLASH_29_1_SQ_060_ITEM_1", 1));
		AddDrop("FLASH_29_1_SQ_060_ITEM_1", 1f, 57920, 57886, 57922);

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_DETECTOR03", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_DETECTOR03", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}
}

