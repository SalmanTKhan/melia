//--- Melia Script -----------------------------------------------------------
// [Event] Daily Mystery Delivery
//--- Description -----------------------------------------------------------
// Quest to Talk to the resident looking for a box.
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

[QuestScript(50314)]
public class Quest50314Script : QuestScript
{
	protected override void Load()
	{
		SetId(50314);
		SetName("[Event] Daily Mystery Delivery");
		SetDescription("Talk to the resident looking for a box");

		AddPrerequisite(new LevelPrerequisite(1));
	}
}

