//--- Melia Script -----------------------------------------------------------
// Recover the Karolis Altar (2)
//--- Description -----------------------------------------------------------
// Quest to Retrieve Karolis Altar Fragments from monsters.
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

[QuestScript(30053)]
public class Quest30053Script : QuestScript
{
	protected override void Load()
	{
		SetId(30053);
		SetName("Recover the Karolis Altar (2)");
		SetDescription("Retrieve Karolis Altar Fragments from monsters");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_04"));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 1026));
	}
}

