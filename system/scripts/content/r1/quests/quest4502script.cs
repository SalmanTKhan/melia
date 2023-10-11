//--- Melia Script -----------------------------------------------------------
// Destroyer of the Main Purifier (3)
//--- Description -----------------------------------------------------------
// Quest to Fix the Main Purifier.
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

[QuestScript(4502)]
public class Quest4502Script : QuestScript
{
	protected override void Load()
	{
		SetId(4502);
		SetName("Destroyer of the Main Purifier (3)");
		SetDescription("Fix the Main Purifier");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_20"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));
	}
}

