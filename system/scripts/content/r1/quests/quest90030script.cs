//--- Melia Script -----------------------------------------------------------
// The Remains of the Wrecked Ship
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Felicia.
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

[QuestScript(90030)]
public class Quest90030Script : QuestScript
{
	protected override void Load()
	{
		SetId(90030);
		SetName("The Remains of the Wrecked Ship");
		SetDescription("Talk to Merchant Felicia");

		AddPrerequisite(new LevelPrerequisite(232));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_MERCHANT2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_11_ST", "CORAL_32_1_SQ_11", "I'll try to find them", "I am not interested"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_11_AG");
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

		if (character.Inventory.HasItem("CORAL_32_1_SQ_11_ITEM2", 1))
		{
			character.Inventory.RemoveItem("CORAL_32_1_SQ_11_ITEM2", 1);
			await dialog.Msg("CORAL_32_1_SQ_11_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

