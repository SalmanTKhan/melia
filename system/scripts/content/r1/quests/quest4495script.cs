//--- Melia Script -----------------------------------------------------------
// Destroyer of the Main Purifier (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Main Purifier.
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

[QuestScript(4495)]
public class Quest4495Script : QuestScript
{
	protected override void Load()
	{
		SetId(4495);
		SetName("Destroyer of the Main Purifier (1)");
		SetDescription("Check the Main Purifier");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_ALCHEMIST"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_PURIFY_7", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

