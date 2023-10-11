//--- Melia Script -----------------------------------------------------------
// Removing Barrier (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Stone Statue of Slogutis.
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

[QuestScript(91208)]
public class Quest91208Script : QuestScript
{
	protected override void Load()
	{
		SetId(91208);
		SetName("Removing Barrier (2)");
		SetDescription("Destroy the Stone Statue of Slogutis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(493));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_3"));

		AddObjective("kill0", "Kill 20 Dark Statue(s)", new KillObjective(20, MonsterId.Ep15_2_Dark_Statue));
		AddObjective("kill1", "Kill 1 Statue", new KillObjective(1, MonsterId.Boss_Roze_Stones_Statue_Curse_Obj));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
	}
}

