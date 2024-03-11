//--- Melia Script -----------------------------------------------------------
// Destroy the Tombstones of Nestopa (2)
//--- Description -----------------------------------------------------------
// Quest to Check the destroyed tombstone.
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

[QuestScript(41040)]
public class Quest41040Script : QuestScript
{
	protected override void Load()
	{
		SetId(41040);
		SetName("Destroy the Tombstones of Nestopa (2)");
		SetDescription("Check the destroyed tombstone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_36_2_SQ_040_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_030"));

		AddDialogHook("PILGRIM_36_2_RUIN", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PILGRIM_36_2_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

