//--- Melia Script -----------------------------------------------------------
// Lizard of Fire
//--- Description -----------------------------------------------------------
// Quest to Check the Barrier Activation Device.
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

[QuestScript(8500)]
public class Quest8500Script : QuestScript
{
	protected override void Load()
	{
		SetId(8500);
		SetName("Lizard of Fire");
		SetDescription("Check the Barrier Activation Device");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER41_SQ_06_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_05"));

		AddObjective("kill0", "Kill 1 Salamander", new KillObjective(1, MonsterId.Boss_Salamander_Q1));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_MQ_05", "BeforeStart", BeforeStart);
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

