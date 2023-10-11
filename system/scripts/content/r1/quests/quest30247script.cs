//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (5)
//--- Description -----------------------------------------------------------
// Quest to Search for Red Ignition Magic Stone in the Office.
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

[QuestScript(30247)]
public class Quest30247Script : QuestScript
{
	protected override void Load()
	{
		SetId(30247);
		SetName("Operation Outer Wall Core Retrieval (5)");
		SetDescription("Search for Red Ignition Magic Stone in the Office");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_4"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CASTLE_20_1_SQ_5_ITEM", 1))
		{
			character.Inventory.RemoveItem("CASTLE_20_1_SQ_5_ITEM", 1);
			await dialog.Msg("NPCAin/CASTLE_20_1_OBJ_4_WALL/dead/1");
			await Task.Delay(1000);
			await dialog.Msg("NPCAin/CASTLE_20_1_OBJ_4/STD/1");
			dialog.HideNPC("CASTLE_20_1_OBJ_4_WALL");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

