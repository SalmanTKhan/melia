//--- Melia Script -----------------------------------------------------------
// Final Conclusion (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Barte.
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

[QuestScript(41120)]
public class Quest41120Script : QuestScript
{
	protected override void Load()
	{
		SetId(41120);
		SetName("Final Conclusion (2)");
		SetDescription("Talk to Barte");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_110"));

		AddObjective("collect0", "Collect 3 Pieces of Leather(s)", new CollectItemObjective("PILGRIM_36_2_SQ_120_ITEM_1", 3));
		AddDrop("PILGRIM_36_2_SQ_120_ITEM_1", 4f, 58107, 58126, 58127, 58130);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_BARTE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_BARTE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_120_ST", "PILGRIM_36_2_SQ_120", "I will try to find it", "Give me some time to prepare"))
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

		if (character.Inventory.HasItem("PILGRIM_36_2_SQ_120_ITEM_1", 3))
		{
			character.Inventory.RemoveItem("PILGRIM_36_2_SQ_120_ITEM_1", 3);
			await dialog.Msg("PILGRIM_36_2_SQ_120_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

