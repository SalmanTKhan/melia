//--- Melia Script -----------------------------------------------------------
// [Daily] Retrieve - Woods of the Linked Bridges
//--- Description -----------------------------------------------------------
// Quest to Defeat monsters in normal fields of Woods of the Linked Bridges and obtain 50 products.
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

[QuestScript(520007)]
public class Quest520007Script : QuestScript
{
	protected override void Load()
	{
		SetId(520007);
		SetName("[Daily] Retrieve - Woods of the Linked Bridges");
		SetDescription("Defeat monsters in normal fields of Woods of the Linked Bridges and obtain 50 products");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("collect0", "Collect 50 Supply of Darbas at the Woods of the Linked Bridges(s)", new CollectItemObjective("P_D_EP13_7_ITEM_1", 50));
		AddDrop("P_D_EP13_7_ITEM_1", 3f, 59580, 59581, 59582);

		AddDialogHook("EP13_F_SIAULIAI_2_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

