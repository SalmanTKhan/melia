//--- Melia Script -----------------------------------------------------------
// An Unlucky Day
//--- Description -----------------------------------------------------------
// Quest to Inspect the Mysterious Trap .
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

[QuestScript(70100)]
public class Quest70100Script : QuestScript
{
	protected override void Load()
	{
		SetId(70100);
		SetName("An Unlucky Day");
		SetDescription("Inspect the Mysterious Trap ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN39_2_MQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(173));

		AddDialogHook("THORN392_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_02", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("THORN39_2_MQ_01_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

