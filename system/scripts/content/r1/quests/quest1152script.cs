//--- Melia Script -----------------------------------------------------------
// Farrier and Funeral [Hackapell Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Hackapell Master.
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

[QuestScript(1152)]
public class Quest1152Script : QuestScript
{
	protected override void Load()
	{
		SetId(1152);
		SetName("Farrier and Funeral [Hackapell Advancement]");
		SetDescription("Call of the Hackapell Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HACKAPELL3_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Hackapell Master", new KillObjective(1, MonsterId.Npc_HAC_Master));

		AddDialogHook("MASTER_HACKAPELL", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HACKAPELL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HACKAPELL3_1_select1", "JOB_HACKAPELL5_1", "I'll accept the duel", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_HACKAPELL3_1_agree1");
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

		await dialog.Msg("JOB_HACKAPELL3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

