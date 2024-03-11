//--- Melia Script -----------------------------------------------------------
// [Daily] Retrieve - Issaugoti Forest
//--- Description -----------------------------------------------------------
// Quest to Defeat monsters in normal fields of Issaugoti Forest and obtain 50 products.
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

[QuestScript(520009)]
public class Quest520009Script : QuestScript
{
	protected override void Load()
	{
		SetId(520009);
		SetName("[Daily] Retrieve - Issaugoti Forest");
		SetDescription("Defeat monsters in normal fields of Issaugoti Forest and obtain 50 products");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("collect0", "Collect 50 Soul of Saugumas at Issaugoti Forest (s)", new CollectItemObjective("P_D_EP13_9_ITEM_1", 50));
		AddDrop("P_D_EP13_9_ITEM_1", 3f, 59587, 59588, 59589);

		AddDialogHook("EP13_F_SIAULIAI_4_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

