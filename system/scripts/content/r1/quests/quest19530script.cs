//--- Melia Script -----------------------------------------------------------
// Can't Be Taken Away (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Zenius.
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

[QuestScript(19530)]
public class Quest19530Script : QuestScript
{
	protected override void Load()
	{
		SetId(19530);
		SetName("Can't Be Taken Away (2)");
		SetDescription("Talk to Pilgrim Zenius");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_090"));

		AddObjective("collect0", "Collect 8 Condensed Cursed Energy(s)", new CollectItemObjective("PILGRIM46_ITEM_08", 8));
		AddDrop("PILGRIM46_ITEM_08", 10f, 41449, 57404, 57402, 41291);

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC04", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_100_ST", "PILGRIM46_SQ_100", "I will test it out", "Leave now"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_100_AC");
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

		if (character.Inventory.HasItem("PILGRIM46_ITEM_08", 8))
		{
			character.Inventory.RemoveItem("PILGRIM46_ITEM_08", 8);
			await dialog.Msg("PILGRIM46_SQ_100_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

