//--- Melia Script -----------------------------------------------------------
// A Stronger Antidote(1)
//--- Description -----------------------------------------------------------
// Quest to Examine Sarma's Research Materials.
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

[QuestScript(30212)]
public class Quest30212Script : QuestScript
{
	protected override void Load()
	{
		SetId(30212);
		SetName("A Stronger Antidote(1)");
		SetDescription("Examine Sarma's Research Materials");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_7"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));
	}
}

