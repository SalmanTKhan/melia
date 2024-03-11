//--- Melia Script -----------------------------------------------------------
// Search for the Trap
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Reina.
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

[QuestScript(70104)]
public class Quest70104Script : QuestScript
{
	protected override void Load()
	{
		SetId(70104);
		SetName("Search for the Trap");
		SetDescription("Talk to Hunter Reina");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ04"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_MQ_05_1", "THORN39_2_MQ05", "Ask him if there's any way to find the trap", "The way to know the owner of the trap", "Wait until the paralysis goes away"))
		{
			case 1:
				await dialog.Msg("THORN39_2_MQ_05_2");
				// Func/SCR_THORN392_MQ_05_COMPANION_GET;
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN39_2_MQ_05_1_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("THORN39_2_MQ05_ITEM", 1))
		{
			character.Inventory.RemoveItem("THORN39_2_MQ05_ITEM", 1);
			await dialog.Msg("THORN39_2_MQ_05_4");
			// Func/SCR_THORN392_COMPANION_RETURN;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

