//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vakarine.
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

[QuestScript(60026)]
public class Quest60026Script : QuestScript
{
	protected override void Load()
	{
		SetId(60026);
		SetName("The Dimensional Crack (4)");
		SetDescription("Talk to Goddess Vakarine");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_03"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4890));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("VPRISON515_MQ_05");
	}
}

