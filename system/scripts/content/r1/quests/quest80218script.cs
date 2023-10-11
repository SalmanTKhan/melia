//--- Melia Script -----------------------------------------------------------
// Ensuring Safety (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Chad.
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

[QuestScript(80218)]
public class Quest80218Script : QuestScript
{
	protected override void Load()
	{
		SetId(80218);
		SetName("Ensuring Safety (2)");
		SetDescription("Talk to the Monk Chad");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN39_1_SQ06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_SQ05"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_SQ06_select01", "THORN39_1_SQ06", "Alright, I'll help you", "I don't think you need to worry."))
		{
			case 1:
				await dialog.Msg("THORN39_1_SQ06_agree01");
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

		await dialog.Msg("THORN39_1_SQ06_succ01");
		// Func/SCR_THORN39_1_SQ06_SUCC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

