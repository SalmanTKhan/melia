//--- Melia Script -----------------------------------------------------------
// I need an indulgence!
//--- Description -----------------------------------------------------------
// Quest to Talk to Kedora Alliance Merchant Alta.
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

[QuestScript(60219)]
public class Quest60219Script : QuestScript
{
	protected override void Load()
	{
		SetId(60219);
		SetName("I need an indulgence!");
		SetDescription("Talk to Kedora Alliance Merchant Alta");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_9"));

		AddObjective("collect0", "Collect 10 Stalactite Chunk(s)", new CollectItemObjective("LSCAVE551_SQB_2_ITEM", 10));
		AddDrop("LSCAVE551_SQB_2_ITEM", 5f, 58477, 58478, 58479, 58570);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQB_2_1", "LSCAVE551_SQB_2", "I will try", "Decline"))
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

		if (character.Inventory.HasItem("LSCAVE551_SQB_2_ITEM", 10))
		{
			character.Inventory.RemoveItem("LSCAVE551_SQB_2_ITEM", 10);
			await dialog.Msg("LSCAVE551_SQB_2_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

