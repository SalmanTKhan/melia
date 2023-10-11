//--- Melia Script -----------------------------------------------------------
// The Worth of a Flower (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edward.
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

[QuestScript(80213)]
public class Quest80213Script : QuestScript
{
	protected override void Load()
	{
		SetId(80213);
		SetName("The Worth of a Flower (2)");
		SetDescription("Talk to Edward");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM49_3_SQ08_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(155));
		AddPrerequisite(new CompletedPrerequisite("FARM49_3_SQ07"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_SQ08_select_01", "FARM49_3_SQ08", "I'll check on it", "That will be hard"))
		{
			case 1:
				await dialog.Msg("FARM49_3_SQ08_agree_01");
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

		await dialog.Msg("FARM49_3_SQ08_succ_01");
		await Task.Delay(500);
		dialog.HideNPC("FARM493_SQ_07");
		await dialog.Msg("FadeOutIN/2500");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

