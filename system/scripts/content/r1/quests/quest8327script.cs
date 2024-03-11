//--- Melia Script -----------------------------------------------------------
// The Wandering Soul (3)
//--- Description -----------------------------------------------------------
// Quest to Check the suspicious location.
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

[QuestScript(8327)]
public class Quest8327Script : QuestScript
{
	protected override void Load()
	{
		SetId(8327);
		SetName("The Wandering Soul (3)");
		SetDescription("Check the suspicious location");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_21_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_20"));

		AddDialogHook("KATYN18_MQ_21_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_GOD", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("KATYN18_MQ_21_03");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("KATYN18_GOD");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

