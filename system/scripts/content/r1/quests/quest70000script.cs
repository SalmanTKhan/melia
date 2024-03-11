//--- Melia Script -----------------------------------------------------------
// The Mysterious Tree
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Ellie.
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

[QuestScript(70000)]
public class Quest70000Script : QuestScript
{
	protected override void Load()
	{
		SetId(70000);
		SetName("The Mysterious Tree");
		SetDescription("Talk to Druid Ellie");

		AddPrerequisite(new LevelPrerequisite(149));

		AddObjective("collect0", "Collect 13 Lizardman Leather(s)", new CollectItemObjective("FARM49_1_MQ01_ITEM", 13));
		AddDrop("FARM49_1_MQ01_ITEM", 9f, "Lizardman_orange");

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_MQ_01_1", "FARM49_1_MQ01", "I'll help", "About the mysterious girl", "Decline since you still have some tasks to complete"))
		{
			case 1:
				await dialog.Msg("FARM49_1_MQ_01_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_1_MQ_01_3");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM49_1_MQ01_ITEM", 13))
		{
			character.Inventory.RemoveItem("FARM49_1_MQ01_ITEM", 13);
			await dialog.Msg("FARM49_1_MQ_01_8");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

