//--- Melia Script -----------------------------------------------------------
// In Search for Another Crystal
//--- Description -----------------------------------------------------------
// Quest to Find Another Black Crystal.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(91201)]
public class Quest91201Script : QuestScript
{
	protected override void Load()
	{
		SetId(91201);
		SetName("In Search for Another Crystal");
		SetDescription("Find Another Black Crystal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_1_MQ_5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_4"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/Func/SCR_EP15_2_D_NICOPOLIS_1_MQ_5_Balloontext;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_2_D_NICOPOLIS_1_MQ_6");
	}
}

