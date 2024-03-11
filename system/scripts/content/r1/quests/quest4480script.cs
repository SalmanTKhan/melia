//--- Melia Script -----------------------------------------------------------
// Activate the Passage Purifier (3)
//--- Description -----------------------------------------------------------
// Quest to Repair the Passage Purifier on 1F.
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

[QuestScript(4480)]
public class Quest4480Script : QuestScript
{
	protected override void Load()
	{
		SetId(4480);
		SetName("Activate the Passage Purifier (3)");
		SetDescription("Repair the Passage Purifier on 1F");

		AddPrerequisite(new LevelPrerequisite(17));
		AddPrerequisite(new CompletedPrerequisite("MINE_1_CRYSTAL_18"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Drug_SP1_Q", 15));
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

