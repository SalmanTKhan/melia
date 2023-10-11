//--- Melia Script -----------------------------------------------------------
// [Daily] Retrieve - Lemprasa Pond
//--- Description -----------------------------------------------------------
// Quest to Defeat monsters in normal fields of Lemprasa Pond and obtain 50 products.
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

[QuestScript(520006)]
public class Quest520006Script : QuestScript
{
	protected override void Load()
	{
		SetId(520006);
		SetName("[Daily] Retrieve - Lemprasa Pond");
		SetDescription("Defeat monsters in normal fields of Lemprasa Pond and obtain 50 products");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("collect0", "Collect 50 Tissue of Liepsna at the Lemprasa Pond(s)", new CollectItemObjective("P_D_EP13_6_ITEM_1", 50));
		AddDrop("P_D_EP13_6_ITEM_1", 3f, 59576, 59577, 59578, 59579);

		AddDialogHook("EP13_F_SIAULIAI_1_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

