//--- Melia Script -----------------------------------------------------------
// Trap after trap(2)
//--- Description -----------------------------------------------------------
// Quest to Getting out of the trap.
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

[QuestScript(70802)]
public class Quest70802Script : QuestScript
{
	protected override void Load()
	{
		SetId(70802);
		SetName("Trap after trap(2)");
		SetDescription("Getting out of the trap");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WHITETREES23_1_SQ03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ02"));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("WHITETREES231_SQ_03");
		dialog.UnHideNPC("WHITETREES231_SQ_03_1");
		dialog.UnHideNPC("WHITETREES231_SQ_03_2");
	}
}

