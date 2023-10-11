//--- Melia Script -----------------------------------------------------------
// Precious to Someone
//--- Description -----------------------------------------------------------
// Quest to The Tombstone at the Meeting Plaza.
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

[QuestScript(19920)]
public class Quest19920Script : QuestScript
{
	protected override void Load()
	{
		SetId(19920);
		SetName("Precious to Someone");
		SetDescription("The Tombstone at the Meeting Plaza");

		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("collect0", "Collect 6 Picture Fragment(s)", new CollectItemObjective("PILGRIM52_SQ_060_ITEM", 6));
		AddDrop("PILGRIM52_SQ_060_ITEM", 10f, 57282, 57279, 57647);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("PILGRIM52_ITEM_05", 1));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_TOMB01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

