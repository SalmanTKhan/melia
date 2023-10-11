//--- Melia Script -----------------------------------------------------------
// Unknown Poison (2)
//--- Description -----------------------------------------------------------
// Quest to Collect Toxic Thorn Tree Stump Sap.
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

[QuestScript(70123)]
public class Quest70123Script : QuestScript
{
	protected override void Load()
	{
		SetId(70123);
		SetName("Unknown Poison (2)");
		SetDescription("Collect Toxic Thorn Tree Stump Sap");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ03"));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN39_1_MQ05");
	}
}

