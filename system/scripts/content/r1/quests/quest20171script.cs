//--- Melia Script -----------------------------------------------------------
// Treasure Hunting (3)
//--- Description -----------------------------------------------------------
// Quest to Check the area Rolandas Jonas told you.
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

[QuestScript(20171)]
public class Quest20171Script : QuestScript
{
	protected override void Load()
	{
		SetId(20171);
		SetName("Treasure Hunting (3)");
		SetDescription("Check the area Rolandas Jonas told you");

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_MQ_2"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1273));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS27_MQ_4");
	}
}

