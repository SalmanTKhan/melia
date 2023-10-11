//--- Melia Script -----------------------------------------------------------
// Demon Lord Helgasercle
//--- Description -----------------------------------------------------------
// Quest to Defeat Helgasercle.
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

[QuestScript(17028)]
public class Quest17028Script : QuestScript
{
	protected override void Load()
	{
		SetId(17028);
		SetName("Demon Lord Helgasercle");
		SetDescription("Defeat Helgasercle");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_PRO"));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));
	}
}

