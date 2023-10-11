//--- Melia Script -----------------------------------------------------------
// Rose the Miserable
//--- Description -----------------------------------------------------------
// Quest to Rescue Rose.
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

[QuestScript(91186)]
public class Quest91186Script : QuestScript
{
	protected override void Load()
	{
		SetId(91186);
		SetName("Rose the Miserable");
		SetDescription("Rescue Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY3_5_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_4"));

		AddObjective("kill0", "Kill 1 Rose the Miserable", new KillObjective(1, MonsterId.Boss_Roze_Q1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_EP15_1_F_ABBEY3_5_1_TRACK;
		var dialog = new Dialog(character, null);
		dialog.HideNPC("EP15_1_FABBEY3_BLOCK");
	}
}

