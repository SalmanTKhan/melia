//--- Melia Script -----------------------------------------------------------
// The Supervisor's Tyranny
//--- Description -----------------------------------------------------------
// Quest to Talk to Farm Supervisor Dorn.
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

[QuestScript(70020)]
public class Quest70020Script : QuestScript
{
	protected override void Load()
	{
		SetId(70020);
		SetName("The Supervisor's Tyranny");
		SetDescription("Talk to Farm Supervisor Dorn");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_MQ05"));

		AddObjective("collect0", "Collect 15 Stumpy Tree Horn Fragment(s)", new CollectItemObjective("FARM49_2_MQ01_ITEM", 15));
		AddDrop("FARM49_2_MQ01_ITEM", 5f, "Stub_tree_orange");

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_01_1", "FARM49_2_MQ01", "I will listen to his requests", "About the farm of Shaton family", "I don't want be controlled"))
		{
			case 1:
				await dialog.Msg("FARM49_2_MQ_01_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_2_MQ_01_3");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM49_2_MQ01_ITEM", 15))
		{
			character.Inventory.RemoveItem("FARM49_2_MQ01_ITEM", 15);
			await dialog.Msg("FARM49_2_MQ_01_5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

