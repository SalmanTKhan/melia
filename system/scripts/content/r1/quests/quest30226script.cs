//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (7)
//--- Description -----------------------------------------------------------
// Quest to Inspect the District 8 Laboratory.
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

[QuestScript(30226)]
public class Quest30226Script : QuestScript
{
	protected override void Load()
	{
		SetId(30226);
		SetName("Investigate Inner Wall District 8 (7)");
		SetDescription("Inspect the District 8 Laboratory");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_7"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));
	}
}

