//--- Melia Script -----------------------------------------------------------
// Demons of the Closed Area
//--- Description -----------------------------------------------------------
// Quest to Examine the suspicious seal.
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

[QuestScript(1048)]
public class Quest1048Script : QuestScript
{
	protected override void Load()
	{
		SetId(1048);
		SetName("Demons of the Closed Area");
		SetDescription("Examine the suspicious seal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_3_BOSS_TRACK", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(21));
		AddPrerequisite(new CompletedPrerequisite("ACT4_MINE3_ENTER"));

		AddObjective("kill0", "Kill 1 Mirtis", new KillObjective(1, MonsterId.Boss_Mirtis));

		AddReward(new ExpReward(32232, 32232));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("CMINE6_TO_KATYN7_1_START", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

