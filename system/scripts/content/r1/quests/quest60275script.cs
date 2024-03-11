//--- Melia Script -----------------------------------------------------------
// Shadow of the Black Wing (4)
//--- Description -----------------------------------------------------------
// Quest to Destroy Demon Dimensional Door.
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

[QuestScript(60275)]
public class Quest60275Script : QuestScript
{
	protected override void Load()
	{
		SetId(60275);
		SetName("Shadow of the Black Wing (4)");
		SetDescription("Destroy Demon Dimensional Door");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB485_MQ_4_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(347));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB485_MQ_3"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));
	}
}

