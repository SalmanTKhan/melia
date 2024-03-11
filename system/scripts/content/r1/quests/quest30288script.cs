//--- Melia Script -----------------------------------------------------------
// Demon Treaty (3)
//--- Description -----------------------------------------------------------
// Quest to Imbue the Impure Blood of Yudejan with Demon Energy.
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

[QuestScript(30288)]
public class Quest30288Script : QuestScript
{
	protected override void Load()
	{
		SetId(30288);
		SetName("Demon Treaty (3)");
		SetDescription("Imbue the Impure Blood of Yudejan with Demon Energy");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_4"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));
	}
}

