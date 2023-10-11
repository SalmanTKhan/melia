//--- Melia Script -----------------------------------------------------------
// Great Words (2)
//--- Description -----------------------------------------------------------
// Quest to Listen to the sermon of Priest Dominikas.
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

[QuestScript(80079)]
public class Quest80079Script : QuestScript
{
	protected override void Load()
	{
		SetId(80079);
		SetName("Great Words (2)");
		SetDescription("Listen to the sermon of Priest Dominikas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY_35_3_SQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_1"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));

		AddDialogHook("ABBEY_35_3_DOMINIKAS", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_DOMINIKAS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ABBEY_35_3_SQ_2_succ");
		// Func/ABBEY_35_3_SQ_2_COMP;
		await dialog.Msg("BalloonText/ABBEY_35_3_SQ_2_FINAL/8");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

