//--- Melia Script -----------------------------------------------------------
// Purify the Toxic Fumes in 2F
//--- Description -----------------------------------------------------------
// Quest to Repair the Purifiers on 2F.
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

[QuestScript(4467)]
public class Quest4467Script : QuestScript
{
	protected override void Load()
	{
		SetId(4467);
		SetName("Purify the Toxic Fumes in 2F");
		SetDescription("Repair the Purifiers on 2F");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_1_ALCHEMIST"));

		AddReward(new ExpReward(48348, 48348));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 2964));
	}
}

