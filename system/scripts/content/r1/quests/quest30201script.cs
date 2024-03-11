//--- Melia Script -----------------------------------------------------------
// Letters from Prison (2)
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

[QuestScript(30201)]
public class Quest30201Script : QuestScript
{
	protected override void Load()
	{
		SetId(30201);
		SetName("Letters from Prison (2)");

		AddPrerequisite(new LevelPrerequisite(9999));
	}
}

