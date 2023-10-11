//--- Melia Script -----------------------------------------------------------
// Anything for the Daughter (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edward.
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

[QuestScript(80208)]
public class Quest80208Script : QuestScript
{
	protected override void Load()
	{
		SetId(80208);
		SetName("Anything for the Daughter (1)");
		SetDescription("Talk to Edward");

		AddPrerequisite(new LevelPrerequisite(149));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_07_select01", "FARM49_1_SQ07", "I can do it.", "I'm busy"))
		{
			case 1:
				await dialog.Msg("FARM49_1_SQ_07_agree01");
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

		if (character.Inventory.HasItem("FARM49_1_SQ07_ITEM1", 1) && character.Inventory.HasItem("FARM49_1_SQ07_ITEM2", 1))
		{
			character.Inventory.RemoveItem("FARM49_1_SQ07_ITEM1", 1);
			character.Inventory.RemoveItem("FARM49_1_SQ07_ITEM2", 1);
			await dialog.Msg("FARM49_1_SQ_07_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

