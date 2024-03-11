//--- Melia Script -----------------------------------------------------------
// I can't read it if I can't see it.
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

[QuestScript(40690)]
public class Quest40690Script : QuestScript
{
	protected override void Load()
	{
		SetId(40690);
		SetName("I can't read it if I can't see it.");

		AddPrerequisite(new LevelPrerequisite(9999));
	}
}

