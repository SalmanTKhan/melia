//--- Melia Script -----------------------------------------------------------
// Rexipher's True Colors (5)
//--- Description -----------------------------------------------------------
// Quest to Activate the Sviesa Altar.
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

[QuestScript(20196)]
public class Quest20196Script : QuestScript
{
	protected override void Load()
	{
		SetId(20196);
		SetName("Rexipher's True Colors (5)");
		SetDescription("Activate the Sviesa Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_MQ8_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ7"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
	}
}

