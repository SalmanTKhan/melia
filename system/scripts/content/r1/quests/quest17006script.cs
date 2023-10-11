//--- Melia Script -----------------------------------------------------------
// Evidence of Bedazzlement (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Cordelier.
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

[QuestScript(17006)]
public class Quest17006Script : QuestScript
{
	protected override void Load()
	{
		SetId(17006);
		SetName("Evidence of Bedazzlement (3)");
		SetDescription("Talk to Cordelier");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER41_SQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_SQ_04"));

		AddObjective("kill0", "Kill 1 Ginklas", new KillObjective(1, MonsterId.Boss_Ginklas_Q2));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("R_Hat_628063", 1));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_SQ_05_ST", "FTOWER41_SQ_05", "I'll go and check on it", "It will be fine"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FTOWER41_SQ_05_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

