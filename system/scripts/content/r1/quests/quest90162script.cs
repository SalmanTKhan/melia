//--- Melia Script -----------------------------------------------------------
// Fast and Precise [Musketeer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Musketeer Master.
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

[QuestScript(90162)]
public class Quest90162Script : QuestScript
{
	protected override void Load()
	{
		SetId(90162);
		SetName("Fast and Precise [Musketeer Advancement]");
		SetDescription("Talk with the Musketeer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_MUSKETEER_8_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MUSKETEER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MUSKETEER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MUSKETEER_8_1_ST", "JOB_MUSKETEER_8_1", "I'm ready", "It doesn't seem to fit for me"))
		{
			case 1:
				await dialog.Msg("JOB_MUSKETEER_8_1_AG");
				dialog.UnHideNPC("JOB_MUSKETEER_8_1_WOOD_CARVING");
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

		await dialog.Msg("JOB_MUSKETEER_8_1_SU");
		dialog.HideNPC("JOB_MUSKETEER_8_1_WOOD_CARVING");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

