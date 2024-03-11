//--- Melia Script -----------------------------------------------------------
// The Legendary Trick (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Donatas.
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

[QuestScript(8514)]
public class Quest8514Script : QuestScript
{
	protected override void Load()
	{
		SetId(8514);
		SetName("The Legendary Trick (1)");
		SetDescription("Talk to Follower Donatas");

		AddPrerequisite(new LevelPrerequisite(44));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_04_1"));

		AddObjective("collect0", "Collect 10 Small Demon's Skirt Hem(s)", new CollectItemObjective("CHAPLE576_MQ_05_ITEM", 10));
		AddDrop("CHAPLE576_MQ_05_ITEM", 7f, 57028, 57213);

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL576_DONATAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL576_DONATAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_MQ_05_01", "CHAPLE576_MQ_05", "That seems fun", "That's blasphemous"))
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

		if (character.Inventory.HasItem("CHAPLE576_MQ_05_ITEM", 10))
		{
			character.Inventory.RemoveItem("CHAPLE576_MQ_05_ITEM", 10);
			await dialog.Msg("CHAPLE576_MQ_05_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

