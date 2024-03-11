//--- Melia Script -----------------------------------------------------------
// Destroy Demon God's Crystal (2)
//--- Description -----------------------------------------------------------
// Quest to Find Another Black Crystal.
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

[QuestScript(91202)]
public class Quest91202Script : QuestScript
{
	protected override void Load()
	{
		SetId(91202);
		SetName("Destroy Demon God's Crystal (2)");
		SetDescription("Find Another Black Crystal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_1_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_5"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_EP15_2_D_NICOPOLIS_1_MQ_6_Balloontext;
	}
}

