//--- Melia Script -----------------------------------------------------------
// Demon Treaty (2)
//--- Description -----------------------------------------------------------
// Quest to Defeat Monsters to Obtain the Impure Blood of Yudejan.
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

[QuestScript(30287)]
public class Quest30287Script : QuestScript
{
	protected override void Load()
	{
		SetId(30287);
		SetName("Demon Treaty (2)");
		SetDescription("Defeat Monsters to Obtain the Impure Blood of Yudejan");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_3"));

		AddObjective("collect0", "Collect 6 Impure Blood of Yudejan(s)", new CollectItemObjective("WTREES_21_1_SQ_4_ITEM", 6));
		AddDrop("WTREES_21_1_SQ_4_ITEM", 5f, 58450, 58447, 58446);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));
	}
}

