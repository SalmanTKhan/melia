//--- Melia Script -----------------------------------------------------------
// Rexipher's True Colors (2)
//--- Description -----------------------------------------------------------
// Quest to Find Rexipher.
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

[QuestScript(20193)]
public class Quest20193Script : QuestScript
{
	protected override void Load()
	{
		SetId(20193);
		SetName("Rexipher's True Colors (2)");
		SetDescription("Find Rexipher");

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ3"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1444));
	}
}

