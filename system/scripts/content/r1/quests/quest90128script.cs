//--- Melia Script -----------------------------------------------------------
// Waiting for Daddy (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Little Willitte.
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

[QuestScript(90128)]
public class Quest90128Script : QuestScript
{
	protected override void Load()
	{
		SetId(90128);
		SetName("Waiting for Daddy (2)");
		SetDescription("Talk with Little Willitte");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_90"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("MAPLE_25_2_VILITA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_VILITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_2_SQ_100_ST", "MAPLE_25_2_SQ_100", "Alright, I'll help you", "Tell him that it would be hard"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_2_SQ_100_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_2_SQ_100_ITEM", 10))
		{
			character.Inventory.RemoveItem("MAPLE_25_2_SQ_100_ITEM", 10);
			await dialog.Msg("MAPLE_25_2_SQ_100_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

