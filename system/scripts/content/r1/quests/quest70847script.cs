//--- Melia Script -----------------------------------------------------------
// Taniel the Second's Royal Mausoleum
//--- Description -----------------------------------------------------------
// Quest to Observe the device's reaction.
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

[QuestScript(70847)]
public class Quest70847Script : QuestScript
{
	protected override void Load()
	{
		SetId(70847);
		SetName("Taniel the Second's Royal Mausoleum");
		SetDescription("Observe the device's reaction");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "WHITETREES23_3_SQ08_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(323));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ07"));

		AddDialogHook("WHITETREES233_SQ_08_1", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_08", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("WHITETREES233_SQ_08_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

