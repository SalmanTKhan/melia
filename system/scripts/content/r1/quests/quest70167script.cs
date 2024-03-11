//--- Melia Script -----------------------------------------------------------
// Notify About the Crisis
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70167)]
public class Quest70167Script : QuestScript
{
	protected override void Load()
	{
		SetId(70167);
		SetName("Notify About the Crisis");
		SetDescription("Talk to Senior Monk Goss");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ07"));

		AddDialogHook("ABBEY394_MQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_08_1", "ABBEY39_4_MQ08", "I'll wait then", "Stop for a while"))
		{
			case 1:
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

		await dialog.Msg("ABBEY39_4_MQ_08_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

