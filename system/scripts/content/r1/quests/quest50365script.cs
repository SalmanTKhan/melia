//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (10)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50365)]
public class Quest50365Script : QuestScript
{
	protected override void Load()
	{
		SetId(50365);
		SetName("Suspiciously Secretive (10)");
		SetDescription("Talk to Agailla Flurry Apparition");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY22_5_SQ11_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ10"));

		AddDialogHook("ABBEY22_5_SUBQ11_NPC1_IN", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY3", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ABBEY22_5_SUBQ10_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

