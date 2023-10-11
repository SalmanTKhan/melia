//--- Melia Script -----------------------------------------------------------
// The enemy is also preparing
//--- Description -----------------------------------------------------------
// Quest to Investigate the area in front of the door.
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

[QuestScript(70601)]
public class Quest70601Script : QuestScript
{
	protected override void Load()
	{
		SetId(70601);
		SetName("The enemy is also preparing");
		SetDescription("Investigate the area in front of the door");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "ABBEY41_6_SQ02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ01"));

		AddDialogHook("ABBEY416_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_02", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ABBEY416_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

