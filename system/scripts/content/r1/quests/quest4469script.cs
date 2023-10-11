//--- Melia Script -----------------------------------------------------------
// Fix the Central Purifier (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Central Purifier.
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

[QuestScript(4469)]
public class Quest4469Script : QuestScript
{
	protected override void Load()
	{
		SetId(4469);
		SetName("Fix the Central Purifier (1)");
		SetDescription("Inspect the Central Purifier");

		AddPrerequisite(new LevelPrerequisite(17));
		AddPrerequisite(new CompletedPrerequisite("MINE_1_ALCHEMIST"));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("MINE_1_PURIFY_5", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

