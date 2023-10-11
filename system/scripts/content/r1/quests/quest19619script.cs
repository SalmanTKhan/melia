//--- Melia Script -----------------------------------------------------------
// Hidden Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to Open the Treasure Chest.
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

[QuestScript(19619)]
public class Quest19619Script : QuestScript
{
	protected override void Load()
	{
		SetId(19619);
		SetName("Hidden Treasure Chest");
		SetDescription("Open the Treasure Chest");

		AddPrerequisite(new LevelPrerequisite(124));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_SQ_080_BOX", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

