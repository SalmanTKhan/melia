//--- Melia Script -----------------------------------------------------------
// Step on Tail [Rogue Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Rogue Master.
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

[QuestScript(8738)]
public class Quest8738Script : QuestScript
{
	protected override void Load()
	{
		SetId(8738);
		SetName("Step on Tail [Rogue Advancement]");
		SetDescription("Call of the Rogue Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_ROGUE5_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Rogue Master", new KillObjective(1, MonsterId.Npc_ROG_Master));

		AddDialogHook("MASTER_ROGUE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ROGUE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ROGUE5_1_01", "JOB_ROGUE5_1", "I'll accept the duel", "I decline your duel request"))
		{
			case 1:
				await dialog.Msg("JOB_ROGUE5_1_02");
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

		await dialog.Msg("JOB_ROGUE5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

