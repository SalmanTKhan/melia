//--- Melia Script -----------------------------------------------------------
// Unknown Recipient
//--- Description -----------------------------------------------------------
// Quest to Check the old letter.
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

[QuestScript(80061)]
public class Quest80061Script : QuestScript
{
	protected override void Load()
	{
		SetId(80061);
		SetName("Unknown Recipient");
		SetDescription("Check the old letter");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_09"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7280));
	}
}

