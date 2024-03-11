//--- Melia Script -----------------------------------------------------------
// Back in time(5)
//--- Description -----------------------------------------------------------
// Quest to Use Goddess Gegute's crystal while avoiding the monsters.
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

[QuestScript(60204)]
public class Quest60204Script : QuestScript
{
	protected override void Load()
	{
		SetId(60204);
		SetName("Back in time(5)");
		SetDescription("Use Goddess Gegute's crystal while avoiding the monsters");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_MQ_2"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14168));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FIRETOWER691_MQ_4");
	}
}

