//--- Melia Script -----------------------------------------------------------
// The Advent of Disaster
//--- Description -----------------------------------------------------------
// Quest to Check the weakened Seal Tower.
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

[QuestScript(16510)]
public class Quest16510Script : QuestScript
{
	protected override void Load()
	{
		SetId(16510);
		SetName("The Advent of Disaster");
		SetDescription("Check the weakened Seal Tower");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_2_SQ_02_TRACK", "m_boss_scenario2");

		AddPrerequisite(new LevelPrerequisite(166));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_MQ_04"));

		AddObjective("kill0", "Kill 1 Taumas", new KillObjective(1, MonsterId.Boss_Taumas));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_SEAL", "BeforeStart", BeforeStart);
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

