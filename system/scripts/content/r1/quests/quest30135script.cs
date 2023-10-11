//--- Melia Script -----------------------------------------------------------
// True Nature of the Research (3)
//--- Description -----------------------------------------------------------
// Quest to Defeat the monsters to collect the fruit juice crystals.
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

[QuestScript(30135)]
public class Quest30135Script : QuestScript
{
	protected override void Load()
	{
		SetId(30135);
		SetName("True Nature of the Research (3)");
		SetDescription("Defeat the monsters to collect the fruit juice crystals");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_5"));

		AddObjective("collect0", "Collect 20 Fruit Juice Crystal(s)", new CollectItemObjective("ORCHARD_34_1_SQ_6_ITEM", 20));
		AddDrop("ORCHARD_34_1_SQ_6_ITEM", 10f, 57453, 58028, 401445);

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 7920));
	}
}

