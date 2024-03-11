//--- Melia Script -----------------------------------------------------------
// Sweet Ointment (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Chad.
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

[QuestScript(70130)]
public class Quest70130Script : QuestScript
{
	protected override void Load()
	{
		SetId(70130);
		SetName("Sweet Ointment (2)");
		SetDescription("Talk to the Monk Chad");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_SQ02"));

		AddObjective("collect0", "Collect 8 Woodluwa Essence(s)", new CollectItemObjective("THORN39_1_SQ03_ITEM", 8));
		AddDrop("THORN39_1_SQ03_ITEM", 10f, "wood_lwa");

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_SQ_03_1", "THORN39_1_SQ03", "I'll help you", "I should go back"))
		{
			case 1:
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

		if (character.Inventory.HasItem("THORN39_1_SQ03_ITEM", 8))
		{
			character.Inventory.RemoveItem("THORN39_1_SQ03_ITEM", 8);
			await dialog.Msg("THORN39_1_SQ_03_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

