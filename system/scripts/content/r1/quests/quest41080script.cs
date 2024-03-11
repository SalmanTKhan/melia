//--- Melia Script -----------------------------------------------------------
// Restoring the Tombstone (3)
//--- Description -----------------------------------------------------------
// Quest to Return to Damijonas.
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

[QuestScript(41080)]
public class Quest41080Script : QuestScript
{
	protected override void Load()
	{
		SetId(41080);
		SetName("Restoring the Tombstone (3)");
		SetDescription("Return to Damijonas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_36_2_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_070"));
		AddPrerequisite(new ItemPrerequisite("PILGRIM_36_2_SQ_070_ITEM_1", 3));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_080_ST", "PILGRIM_36_2_SQ_080", "Alright", "You don't have to apologize anymore"))
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

		await dialog.Msg("PILGRIM_36_2_SQ_080_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

