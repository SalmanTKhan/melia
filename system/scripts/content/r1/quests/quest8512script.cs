//--- Melia Script -----------------------------------------------------------
// To Pilgrim's Way
//--- Description -----------------------------------------------------------
// Quest to Move to Starving Demon's Way.
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

[QuestScript(8512)]
public class Quest8512Script : QuestScript
{
	protected override void Load()
	{
		SetId(8512);
		SetName("To Pilgrim's Way");
		SetDescription("Move to Starving Demon's Way");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_06"));
	}
}

