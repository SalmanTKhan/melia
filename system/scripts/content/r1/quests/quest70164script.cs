//--- Melia Script -----------------------------------------------------------
// Mission to Retake the Monastery (5)
//--- Description -----------------------------------------------------------
// Quest to Move to the front of the Prayer Room.
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

[QuestScript(70164)]
public class Quest70164Script : QuestScript
{
	protected override void Load()
	{
		SetId(70164);
		SetName("Mission to Retake the Monastery (5)");
		SetDescription("Move to the front of the Prayer Room");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ04"));

		AddDialogHook("ABBEY394_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_06", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ABBEY39_4_MQ_05_1");
		dialog.UnHideNPC("ABBEY394_MQ_07");
		dialog.HideNPC("ABBEY394_MQ_03_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

