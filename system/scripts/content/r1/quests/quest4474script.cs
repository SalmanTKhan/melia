//--- Melia Script -----------------------------------------------------------
// Activate the Passage Purifier (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Passage Purifier on 1F.
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

[QuestScript(4474)]
public class Quest4474Script : QuestScript
{
	protected override void Load()
	{
		SetId(4474);
		SetName("Activate the Passage Purifier (1)");
		SetDescription("Inspect the Passage Purifier on 1F");

		AddPrerequisite(new LevelPrerequisite(17));
		AddPrerequisite(new CompletedPrerequisite("MINE_1_ALCHEMIST"));

		AddReward(new ExpReward(8058, 8058));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("MINE_1_PURIFY_7", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

