//--- Melia Script -----------------------------------------------------------
// The String of Destiny, and The Wandering (1)
//--- Description -----------------------------------------------------------
// Quest to Discover the tablet.
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

[QuestScript(40490)]
public class Quest40490Script : QuestScript
{
	protected override void Load()
	{
		SetId(40490);
		SetName("The String of Destiny, and The Wandering (1)");
		SetDescription("Discover the tablet");

		AddPrerequisite(new LevelPrerequisite(168));

		AddObjective("collect0", "Collect 2 Loot Bag(s)", new CollectItemObjective("REMAINS37_1_SQ_010_ITEM_1", 2));
		AddDrop("REMAINS37_1_SQ_010_ITEM_1", 10f, "Wendigo_magician");

		AddDialogHook("REMAINS37_1_MT01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_010_ST", "REMAINS37_1_SQ_010", "Let's obtain the materials for rubber copies around here", "Not really my problem"))
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

		if (character.Inventory.HasItem("REMAINS37_1_SQ_010_ITEM_1", 2))
		{
			character.Inventory.RemoveItem("REMAINS37_1_SQ_010_ITEM_1", 2);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have found adequate materials to make rubbings from the monster's inventory");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

