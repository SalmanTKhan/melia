//--- Melia Script -----------------------------------------------------------
// [Daily] Retrieve - Paupys Crossing
//--- Description -----------------------------------------------------------
// Quest to Defeat monsters in normal fields of Paupys Crossing and obtain 50 products.
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

[QuestScript(520008)]
public class Quest520008Script : QuestScript
{
	protected override void Load()
	{
		SetId(520008);
		SetName("[Daily] Retrieve - Paupys Crossing");
		SetDescription("Defeat monsters in normal fields of Paupys Crossing and obtain 50 products");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("collect0", "Collect 50 Blood of Demon at Paupys Crossing(s)", new CollectItemObjective("P_D_EP13_8_ITEM_1", 50));
		AddDrop("P_D_EP13_8_ITEM_1", 3f, 59583, 59584, 59585, 59586);

		AddDialogHook("EP13_F_SIAULIAI_3_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

