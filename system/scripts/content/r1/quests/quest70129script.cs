//--- Melia Script -----------------------------------------------------------
// Sweet Ointment (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Chad.
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

[QuestScript(70129)]
public class Quest70129Script : QuestScript
{
	protected override void Load()
	{
		SetId(70129);
		SetName("Sweet Ointment (1)");
		SetDescription("Talk to the Monk Chad");

		AddPrerequisite(new LevelPrerequisite(176));

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

		switch (await dialog.Select("THORN39_1_SQ_02_1", "THORN39_1_SQ02", "Sure, I'll help", "Tell him that you have more urgent issue that that"))
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

		if (character.Inventory.HasItem("THORN39_1_SQ02_ITEM", 4))
		{
			character.Inventory.RemoveItem("THORN39_1_SQ02_ITEM", 4);
			await dialog.Msg("THORN39_1_SQ_02_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

