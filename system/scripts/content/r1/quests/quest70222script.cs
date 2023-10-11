//--- Melia Script -----------------------------------------------------------
// Demand for Food Supplies
//--- Description -----------------------------------------------------------
// Quest to Talk with Supply Officer Ronda.
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

[QuestScript(70222)]
public class Quest70222Script : QuestScript
{
	protected override void Load()
	{
		SetId(70222);
		SetName("Demand for Food Supplies");
		SetDescription("Talk with Supply Officer Ronda");

		AddPrerequisite(new LevelPrerequisite(215));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_03_1", "TABLELAND28_2_SQ03", "That won't be a problem", "Decline"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_03_2");
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

		if (character.Inventory.HasItem("TABLELAND28_2_SQ03_ITEM", 9))
		{
			character.Inventory.RemoveItem("TABLELAND28_2_SQ03_ITEM", 9);
			await dialog.Msg("TABLELAND28_2_SQ_03_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

