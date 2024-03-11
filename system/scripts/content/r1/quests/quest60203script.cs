//--- Melia Script -----------------------------------------------------------
// Back in time(4)
//--- Description -----------------------------------------------------------
// Quest to Collect Time magic.
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

[QuestScript(60203)]
public class Quest60203Script : QuestScript
{
	protected override void Load()
	{
		SetId(60203);
		SetName("Back in time(4)");
		SetDescription("Collect Time magic");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_MQ_1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14168));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FIRETOWER691_MQ_3");
	}
}

