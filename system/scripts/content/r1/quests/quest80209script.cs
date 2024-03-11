//--- Melia Script -----------------------------------------------------------
// Anything for the Daughter (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edward.
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

[QuestScript(80209)]
public class Quest80209Script : QuestScript
{
	protected override void Load()
	{
		SetId(80209);
		SetName("Anything for the Daughter (2)");
		SetDescription("Talk to Edward");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM49_1_SQ08_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(149));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_SQ07"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_08_select01", "FARM49_1_SQ08", "I'll try to find them", "I am not interested"))
		{
			case 1:
				await dialog.Msg("FARM49_1_SQ_08_agree01");
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

		await dialog.Msg("FARM49_1_SQ_08_succ01");
		await Task.Delay(500);
		dialog.HideNPC("FARM491_SQ_07");
		dialog.UnHideNPC("FARM492_SQ_07");
		await dialog.Msg("FadeOutIN/2500");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

