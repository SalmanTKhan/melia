//--- Melia Script -----------------------------------------------------------
// The Immortal Nepenthes (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Erra.
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

[QuestScript(8603)]
public class Quest8603Script : QuestScript
{
	protected override void Load()
	{
		SetId(8603);
		SetName("The Immortal Nepenthes (1)");
		SetDescription("Talk to Watcher Erra");

		AddPrerequisite(new LevelPrerequisite(35));

		AddObjective("collect0", "Collect 10 Mallardu Fat(s)", new CollectItemObjective("GELE574_MQ_03_ITEM", 10));
		AddDrop("GELE574_MQ_03_ITEM", 10f, "Mallardu");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_ERRA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ERRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_03_01", "GELE574_MQ_03", "Yeah, I'll collect them", "I'll wait a little bit"))
		{
			case 1:
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

		if (character.Inventory.HasItem("GELE574_MQ_03_ITEM", 10))
		{
			character.Inventory.RemoveItem("GELE574_MQ_03_ITEM", 10);
			await dialog.Msg("GELE574_MQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

