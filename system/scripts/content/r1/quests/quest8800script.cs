//--- Melia Script -----------------------------------------------------------
// Welcomed Uninvited Guest
//--- Description -----------------------------------------------------------
// Quest to Enter Verkti Square.
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

[QuestScript(8800)]
public class Quest8800Script : QuestScript
{
	protected override void Load()
	{
		SetId(8800);
		SetName("Welcomed Uninvited Guest");
		SetDescription("Enter Verkti Square");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH59_SQ_01_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(184));

		AddDialogHook("FLASH59_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FLASH59_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

