//--- Melia Script -----------------------------------------------------------
// Basic Type
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(1)]
public class Quest1Script : QuestScript
{
	protected override void Load()
	{
		SetId(1);
		SetName("Basic Type");

		AddPrerequisite(new LevelPrerequisite(1));
	}
}

