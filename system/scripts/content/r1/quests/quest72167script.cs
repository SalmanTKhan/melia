//--- Melia Script -----------------------------------------------------------
// Magic Studies of Psychokino
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Master.
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

[QuestScript(72167)]
public class Quest72167Script : QuestScript
{
	protected override void Load()
	{
		SetId(72167);
		SetName("Magic Studies of Psychokino");
		SetDescription("Talk to the Psychokino Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_PSYCHOKINO1_DLG1", "MASTER_PSYCHOKINO1", "Where can I find it?", "Tell him you don't need it"))
		{
			case 1:
				await dialog.Msg("JOB_2_PSYCHOKINO_5_1_agree");
				dialog.UnHideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_1");
				dialog.UnHideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_2");
				dialog.UnHideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_3");
				dialog.UnHideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_4");
				dialog.UnHideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_5");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("MASTER_PSYCHOKINO1_DLG2");
		dialog.HideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_1");
		dialog.HideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_2");
		dialog.HideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_3");
		dialog.HideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_4");
		dialog.HideNPC("JOB_2_PSYCHOKINO_5_1_BOOK_5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

