//--- Melia Script -----------------------------------------------------------
// The Restrained Spirit of Zanas(1)
//--- Description -----------------------------------------------------------
// Quest to Obtain the Spirit Stone of Restrainment by defeating monsters.
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

[QuestScript(30176)]
public class Quest30176Script : QuestScript
{
	protected override void Load()
	{
		SetId(30176);
		SetName("The Restrained Spirit of Zanas(1)");
		SetDescription("Obtain the Spirit Stone of Restrainment by defeating monsters");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_2"));

		AddObjective("collect0", "Collect 10 Soul Stone of Restrainment(s)", new CollectItemObjective("PRISON_81_MQ_3_ITEM", 10));
		AddDrop("PRISON_81_MQ_3_ITEM", 10f, 57985, 57987, 57952);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));
	}
}

