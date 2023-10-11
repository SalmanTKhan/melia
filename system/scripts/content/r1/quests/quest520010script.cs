//--- Melia Script -----------------------------------------------------------
// [Daily] Retrieve - Kirtimas Forest
//--- Description -----------------------------------------------------------
// Quest to Defeat monsters in normal fields of Kirtimas Forest and obtain 50 products.
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

[QuestScript(520010)]
public class Quest520010Script : QuestScript
{
	protected override void Load()
	{
		SetId(520010);
		SetName("[Daily] Retrieve - Kirtimas Forest");
		SetDescription("Defeat monsters in normal fields of Kirtimas Forest and obtain 50 products");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("collect0", "Collect 50 Fragment of Demon at Kirtimas Forest(s)", new CollectItemObjective("P_D_EP13_10_ITEM_1", 50));
		AddDrop("P_D_EP13_10_ITEM_1", 3f, 59590, 59591, 59592, 59593);

		AddDialogHook("EP13_F_SIAULIAI_5_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

