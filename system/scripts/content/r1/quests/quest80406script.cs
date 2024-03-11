//--- Melia Script -----------------------------------------------------------
// The Art of Assassination
//--- Description -----------------------------------------------------------
// Quest to Talk to the Assassin Master.
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

[QuestScript(80406)]
public class Quest80406Script : QuestScript
{
	protected override void Load()
	{
		SetId(80406);
		SetName("The Art of Assassination");
		SetDescription("Talk to the Assassin Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_ASSASSIN_Q1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("ASSASSIN_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("ASSASSIN_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ASSASSIN_Q1_ST1", "JOB_ASSASSIN_Q1", "Can you tell me more...?", "I'll have to pass, sorry."))
		{
			case 1:
				await dialog.Msg("JOB_ASSASSIN_Q1_AFST");
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

		await dialog.Msg("JOB_ASSASSIN_Q1_SU1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

