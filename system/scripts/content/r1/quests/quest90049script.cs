//--- Melia Script -----------------------------------------------------------
// For the Monster Statue
//--- Description -----------------------------------------------------------
// Quest to Talk to Trainee Leryd.
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

[QuestScript(90049)]
public class Quest90049Script : QuestScript
{
	protected override void Load()
	{
		SetId(90049);
		SetName("For the Monster Statue");
		SetDescription("Talk to Trainee Leryd");

		AddPrerequisite(new LevelPrerequisite(249));

		AddObjective("collect0", "Collect 1 Black Old Kepa Stems", new CollectItemObjective("KATYN_45_2_SQ_8_ITEM1", 1));
		AddObjective("collect1", "Collect 4 Red Puragi Hook(s)", new CollectItemObjective("KATYN_45_2_SQ_8_ITEM2", 4));
		AddObjective("collect2", "Collect 8 Blue Ridimed Leaves(s)", new CollectItemObjective("KATYN_45_2_SQ_8_ITEM3", 8));
		AddDrop("KATYN_45_2_SQ_8_ITEM1", 8f, "pappus_kepa_purple");
		AddDrop("KATYN_45_2_SQ_8_ITEM2", 8f, "puragi_red");
		AddDrop("KATYN_45_2_SQ_8_ITEM3", 8f, "Ridimed_blue");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_SCULPTOR1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_SCULPTOR1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_8_ST", "KATYN_45_2_SQ_8", "I'll listen.", "I'm busy"))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_8_AG");
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

		if (character.Inventory.HasItem("KATYN_45_2_SQ_8_ITEM1", 1) && character.Inventory.HasItem("KATYN_45_2_SQ_8_ITEM2", 4) && character.Inventory.HasItem("KATYN_45_2_SQ_8_ITEM3", 8))
		{
			character.Inventory.RemoveItem("KATYN_45_2_SQ_8_ITEM1", 1);
			character.Inventory.RemoveItem("KATYN_45_2_SQ_8_ITEM2", 4);
			character.Inventory.RemoveItem("KATYN_45_2_SQ_8_ITEM3", 8);
			await dialog.Msg("KATYN_45_2_SQ_8_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

