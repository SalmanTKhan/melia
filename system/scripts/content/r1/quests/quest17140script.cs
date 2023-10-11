//--- Melia Script -----------------------------------------------------------
// Collecting Cable Car Parts
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Matthew.
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

[QuestScript(17140)]
public class Quest17140Script : QuestScript
{
	protected override void Load()
	{
		SetId(17140);
		SetName("Collecting Cable Car Parts");
		SetDescription("Talk to Watcher Matthew");

		AddPrerequisite(new LevelPrerequisite(26));

		AddObjective("collect0", "Collect 7 Cable Car Parts(s)", new CollectItemObjective("GELE571_MQ_05_ITEM", 7));
		AddDrop("GELE571_MQ_05_ITEM", 6.5f, "Zignuts");

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_MATTHEW", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MATTHEW", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_05_01", "GELE571_MQ_05", "I'll find it for you", "About the Holy Land", "That's too bad (leave)"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_05_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("GELE571_MQ_05_ITEM", 7))
		{
			character.Inventory.RemoveItem("GELE571_MQ_05_ITEM", 7);
			await dialog.Msg("GELE571_MQ_05_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

