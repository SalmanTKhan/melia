//--- Melia Script -----------------------------------------------------------
// Circulation Purifier Issues (2)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Purifier Pipe in District 2.
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

[QuestScript(4484)]
public class Quest4484Script : QuestScript
{
	protected override void Load()
	{
		SetId(4484);
		SetName("Circulation Purifier Issues (2)");
		SetDescription("Inspect the Purifier Pipe in District 2");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_2_CRYSTAL_3_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_2"));

		AddObjective("kill0", "Kill 1 Carapace", new KillObjective(1, MonsterId.Boss_Carapace));

		AddReward(new ExpReward(16116, 16116));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MINE_2_CRYSTAL_4");
	}
}

