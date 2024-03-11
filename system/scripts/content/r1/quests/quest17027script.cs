//--- Melia Script -----------------------------------------------------------
// Goddess' Tower
//--- Description -----------------------------------------------------------
// Quest to Find the goddess in Mage Tower 5F.
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

[QuestScript(17027)]
public class Quest17027Script : QuestScript
{
	protected override void Load()
	{
		SetId(17027);
		SetName("Goddess' Tower");
		SetDescription("Find the goddess in Mage Tower 5F");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_MQ_05"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));
	}
}

