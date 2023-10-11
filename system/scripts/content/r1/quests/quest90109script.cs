//--- Melia Script -----------------------------------------------------------
// Autumn Leaves (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Forest Keeper Brunonas.
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

[QuestScript(90109)]
public class Quest90109Script : QuestScript
{
	protected override void Load()
	{
		SetId(90109);
		SetName("Autumn Leaves (2)");
		SetDescription("Talk to Forest Keeper Brunonas");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_10"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("MAPLE_25_1_SQ_ITEM1", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_BRONIUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_BRONIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_20_ST", "MAPLE_25_1_SQ_20", "I'll get it. ", "That's tough"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_20_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_1_SQ_20_ITEM", 6))
		{
			character.Inventory.RemoveItem("MAPLE_25_1_SQ_20_ITEM", 6);
			await dialog.Msg("MAPLE_25_1_SQ_20_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

