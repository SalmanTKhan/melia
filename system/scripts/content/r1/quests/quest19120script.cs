//--- Melia Script -----------------------------------------------------------
// Activities of a Chronomancer [Chronomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(19120)]
public class Quest19120Script : QuestScript
{
	protected override void Load()
	{
		SetId(19120);
		SetName("Activities of a Chronomancer [Chronomancer Advancement]");
		SetDescription("Talk to the Chronomancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_WARLOCK4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(1, MonsterId.Boss_Reaverpede_J1));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CHRONO4_1_ST", "JOB_CHRONO4_1", "I will defeat the Reaverpede", "Give me some time to prepare"))
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

		await dialog.Msg("JOB_CHRONO4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

