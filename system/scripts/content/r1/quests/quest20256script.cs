//--- Melia Script -----------------------------------------------------------
// In the Name of Faith (2)
//--- Description -----------------------------------------------------------
// Quest to Collect Operor stingers to refine the magic crystal with..
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

[QuestScript(20256)]
public class Quest20256Script : QuestScript
{
	protected override void Load()
	{
		SetId(20256);
		SetName("In the Name of Faith (2)");
		SetDescription("Collect Operor stingers to refine the magic crystal with.");

		AddPrerequisite(new LevelPrerequisite(59));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ11"));

		AddObjective("collect0", "Collect 6 Operor's Stinger(s)", new CollectItemObjective("THORN19_MQ9_PURIFY", 6));
		AddDrop("THORN19_MQ9_PURIFY", 10f, "operor");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1062));
	}
}

