//--- Melia Script -----------------------------------------------------------
// Alcor's Trial [Centurion Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master in Fedimian.
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

[QuestScript(1150)]
public class Quest1150Script : QuestScript
{
	protected override void Load()
	{
		SetId(1150);
		SetName("Alcor's Trial [Centurion Advancement]");
		SetDescription("Talk to the Centurion Master in Fedimian");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CENTURION3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Security Guard", new KillObjective(1, MonsterId.SCS_M2_Mon));

		AddDialogHook("JOB_CENTURION3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CENTURION3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CENTURION3_1_select1", "JOB_CENTURION3_1", "Accept the duel with the Master", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_CENTURION3_1_agree1");
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

		await dialog.Msg("JOB_CENTURION3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

