//--- Melia Script -----------------------------------------------------------
// Know Your Enemy, Know Yourself (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Schaffenstar Adjutant Apollonius.
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

[QuestScript(72218)]
public class Quest72218Script : QuestScript
{
	protected override void Load()
	{
		SetId(72218);
		SetName("Know Your Enemy, Know Yourself (1)");
		SetDescription("Talk to Schaffenstar Adjutant Apollonius");

		AddPrerequisite(new LevelPrerequisite(392));
		AddPrerequisite(new CompletedPrerequisite("CASTLE93_MAIN02"));

		AddObjective("collect0", "Collect 10 Demon Orders(s)", new CollectItemObjective("CASTLE93_MAIN03_ITEM", 10));
		AddDrop("CASTLE93_MAIN03_ITEM", 5f, 59219, 59249, 59247);

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 20723));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE93_MAIN03_01", "CASTLE93_MAIN03", "Alright", "Let me go get ready, then."))
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

		if (character.Inventory.HasItem("CASTLE93_MAIN03_ITEM", 10))
		{
			character.Inventory.RemoveItem("CASTLE93_MAIN03_ITEM", 10);
			await dialog.Msg("CASTLE93_MAIN03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

