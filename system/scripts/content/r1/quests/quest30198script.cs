//--- Melia Script -----------------------------------------------------------
// Storage Room's Suspicious Secret Device
//--- Description -----------------------------------------------------------
// Quest to Check the Secret Device on the way to Supply Depot Number 1.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(30198)]
public class Quest30198Script : QuestScript
{
	protected override void Load()
	{
		SetId(30198);
		SetName("Storage Room's Suspicious Secret Device");
		SetDescription("Check the Secret Device on the way to Supply Depot Number 1");

		AddPrerequisite(new LevelPrerequisite(9999));
	}
}

