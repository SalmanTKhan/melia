//--- Melia Script -----------------------------------------------------------
// Activate the Device
//--- Description -----------------------------------------------------------
// Quest to Release all seals of Tiltas Valley.
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

[QuestScript(20175)]
public class Quest20175Script : QuestScript
{
	protected override void Load()
	{
		SetId(20175);
		SetName("Activate the Device");
		SetDescription("Release all seals of Tiltas Valley");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_MQ_6"));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 14421));
	}
}

