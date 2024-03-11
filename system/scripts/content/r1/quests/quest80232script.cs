//--- Melia Script -----------------------------------------------------------
// Defeat the Incoming Demons
//--- Description -----------------------------------------------------------
// Quest to Find the Saalus Convent.
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

[QuestScript(80232)]
public class Quest80232Script : QuestScript
{
	protected override void Load()
	{
		SetId(80232);
		SetName("Defeat the Incoming Demons");
		SetDescription("Find the Saalus Convent");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(301560, 301560));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 3000));
	}
}

