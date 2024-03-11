//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (1)
//--- Description -----------------------------------------------------------
// Quest to Look at the tombstone at the Hall of the Past.
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

[QuestScript(40590)]
public class Quest40590Script : QuestScript
{
	protected override void Load()
	{
		SetId(40590);
		SetName("The Second Epitaph (1)");
		SetDescription("Look at the tombstone at the Hall of the Past");

		AddPrerequisite(new LevelPrerequisite(172));

		AddObjective("collect0", "Collect 6 Tombstone Fragment(s)", new CollectItemObjective("REMAINS37_2_SQ_030_ITEM_1", 6));
		AddDrop("REMAINS37_2_SQ_030_ITEM_1", 10f, 41302, 57615);

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT02_BROKEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAINS37_2_SQ_030_ITEM_1", 6))
		{
			character.Inventory.RemoveItem("REMAINS37_2_SQ_030_ITEM_1", 6);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "It will be hard to restore it without some sort of glue.{nl}Ask the blacksmith in Klaipeda for a glue!", 5);
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

