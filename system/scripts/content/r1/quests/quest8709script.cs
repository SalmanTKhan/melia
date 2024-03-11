//--- Melia Script -----------------------------------------------------------
// Pirate on Land [Corsair Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Corsair Master.
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

[QuestScript(8709)]
public class Quest8709Script : QuestScript
{
	protected override void Load()
	{
		SetId(8709);
		SetName("Pirate on Land [Corsair Advancement]");
		SetDescription("Meet the Corsair Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("collect0", "Collect 1 Dock Permit", new CollectItemObjective("JOB_CORSAIR4_1_ITEM_01", 1));
		AddObjective("collect1", "Collect 3 Navigator's Chart(s)", new CollectItemObjective("JOB_CORSAIR4_1_ITEM_02", 3));
		AddObjective("collect2", "Collect 10 Contract(s)", new CollectItemObjective("JOB_CORSAIR4_1_ITEM_03", 10));
		AddDrop("JOB_CORSAIR4_1_ITEM_01", 1f, "Prisonfighter");
		AddDrop("JOB_CORSAIR4_1_ITEM_02", 3f, "Prisonfighter");
		AddDrop("JOB_CORSAIR4_1_ITEM_03", 5f, "Prisonfighter");

		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CORSAIR4_1_01", "JOB_CORSAIR4_1", "I'll get everything back", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_CORSAIR4_1_02");
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

		if (character.Inventory.HasItem("JOB_CORSAIR4_1_ITEM_01", 1) && character.Inventory.HasItem("JOB_CORSAIR4_1_ITEM_02", 3) && character.Inventory.HasItem("JOB_CORSAIR4_1_ITEM_03", 10))
		{
			character.Inventory.RemoveItem("JOB_CORSAIR4_1_ITEM_01", 1);
			character.Inventory.RemoveItem("JOB_CORSAIR4_1_ITEM_02", 3);
			character.Inventory.RemoveItem("JOB_CORSAIR4_1_ITEM_03", 10);
			await dialog.Msg("JOB_CORSAIR4_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

