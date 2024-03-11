//--- Melia Script -----------------------------------------------------------
// To Goddess Saule
//--- Description -----------------------------------------------------------
// Quest to Retrieve the revelation.
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

[QuestScript(20275)]
public class Quest20275Script : QuestScript
{
	protected override void Load()
	{
		SetId(20275);
		SetName("To Goddess Saule");
		SetDescription("Retrieve the revelation");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ07"));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 1216));
	}
}

