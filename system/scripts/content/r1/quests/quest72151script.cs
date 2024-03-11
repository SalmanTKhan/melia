//--- Melia Script -----------------------------------------------------------
// A Scholarly Question
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(72151)]
public class Quest72151Script : QuestScript
{
	protected override void Load()
	{
		SetId(72151);
		SetName("A Scholarly Question");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MASTER_FIREMAGE1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(15));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_FIREMAGE1_DLG1", "MASTER_FIREMAGE1", "I'll help with the research", "I'll come back next time"))
		{
			case 1:
				await dialog.Msg("JOB_FIREMAGE1_AG");
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

		await dialog.Msg("MASTER_FIREMAGE1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

