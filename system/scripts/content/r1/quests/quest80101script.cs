//--- Melia Script -----------------------------------------------------------
// Evil Magic Circles? (3)
//--- Description -----------------------------------------------------------
// Quest to Find another way to destroy the magic circles.
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

[QuestScript(80101)]
public class Quest80101Script : QuestScript
{
	protected override void Load()
	{
		SetId(80101);
		SetName("Evil Magic Circles? (3)");
		SetDescription("Find another way to destroy the magic circles");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_2"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("BalloonText/CORAL_35_2_SQ_3_start/15");
	}
}

