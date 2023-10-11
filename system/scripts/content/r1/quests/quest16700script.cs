//--- Melia Script -----------------------------------------------------------
// Chafer of the Spring Light Woods
//--- Description -----------------------------------------------------------
// Quest to Check the Spring Light Woods Altar.
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

[QuestScript(16700)]
public class Quest16700Script : QuestScript
{
	protected override void Load()
	{
		SetId(16700);
		SetName("Chafer of the Spring Light Woods");
		SetDescription("Check the Spring Light Woods Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_1_SQ_01_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(169));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_01"), new CompletedPrerequisite("SIAULIAI_46_1_MQ_02"));

		AddObjective("kill0", "Kill 1 Chafer", new KillObjective(1, MonsterId.Boss_Chafer_Q3));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_ALTAR", "BeforeStart", BeforeStart);
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

