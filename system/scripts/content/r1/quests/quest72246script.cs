//--- Melia Script -----------------------------------------------------------
// Demon God Ragana (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72246)]
public class Quest72246Script : QuestScript
{
	protected override void Load()
	{
		SetId(72246);
		SetName("Demon God Ragana (2)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_PRELUDE_09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(420));
		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_08"));

		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_106B", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_106C", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_PRELUDE_09_DLG01", "EP12_PRELUDE_09", "Say we should move cautiously", "Ask to turn back because it's dangerous"))
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

		await dialog.Msg("EP12_PRELUDE_09_DLG17");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

