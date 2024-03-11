//--- Melia Script -----------------------------------------------------------
// News of Victory
//--- Description -----------------------------------------------------------
// Quest to All-out attack to the Front Yard.
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

[QuestScript(91124)]
public class Quest91124Script : QuestScript
{
	protected override void Load()
	{
		SetId(91124);
		SetName("News of Victory");
		SetDescription("All-out attack to the Front Yard");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE5_MQ_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(468));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_7"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_8_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP14_1_FCASTLE5_MQ_8_CNPC_DLG1");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

