//--- Melia Script -----------------------------------------------------------
// The First Mission
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Adelle.
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

[QuestScript(20143)]
public class Quest20143Script : QuestScript
{
	protected override void Load()
	{
		SetId(20143);
		SetName("The First Mission");
		SetDescription("Talk to Historian Adelle");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("ROKAS28_MQ1"));

		AddObjective("collect0", "Collect 10 Strangely Engraved Stone(s)", new CollectItemObjective("ROKAS28_MQ2_ITEM", 10));
		AddDrop("ROKAS28_MQ2_ITEM", 10f, "hogma_archer");

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_ODEL", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_ODEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS28_MQ2_select", "ROKAS28_MQ2", "I'm curious", "I don't want to know"))
		{
			case 1:
				await dialog.Msg("ROKAS28_MQ2_select_Q");
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

		if (character.Inventory.HasItem("ROKAS28_MQ2_ITEM", 10))
		{
			character.Inventory.RemoveItem("ROKAS28_MQ2_ITEM", 10);
			await dialog.Msg("ROKAS28_MQ2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

