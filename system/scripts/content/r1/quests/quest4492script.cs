//--- Melia Script -----------------------------------------------------------
// Inoperable Auxiliary Purifier (4)
//--- Description -----------------------------------------------------------
// Quest to Activate the Auxiliary Purifier on 2F.
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

[QuestScript(4492)]
public class Quest4492Script : QuestScript
{
	protected override void Load()
	{
		SetId(4492);
		SetName("Inoperable Auxiliary Purifier (4)");
		SetDescription("Activate the Auxiliary Purifier on 2F");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_10"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));
	}
}

