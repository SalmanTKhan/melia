//--- Melia Script -----------------------------------------------------------
// Poisons to Use [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Look for the Wugushi Submaster .
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

[QuestScript(8720)]
public class Quest8720Script : QuestScript
{
	protected override void Load()
	{
		SetId(8720);
		SetName("Poisons to Use [Wugushi Advancement]");
		SetDescription("Look for the Wugushi Submaster ");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("collect0", "Collect 10 Synthetic Poison(s)", new CollectItemObjective("JOB_WUGU4_1_ITEM_1", 10));
		AddDrop("JOB_WUGU4_1_ITEM_1", 10f, "honey_bee");

		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WUGU4_1_01", "JOB_WUGU4_1", "I will collect the poison", "Sorry, it's too dangerous"))
		{
			case 1:
				await dialog.Msg("JOB_WUGU4_1_02");
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

		if (character.Inventory.HasItem("JOB_WUGU4_1_ITEM_1", 10))
		{
			character.Inventory.RemoveItem("JOB_WUGU4_1_ITEM_1", 10);
			await dialog.Msg("JOB_WUGU4_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

