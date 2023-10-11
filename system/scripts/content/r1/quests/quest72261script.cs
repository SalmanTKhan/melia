//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (2)
//--- Description -----------------------------------------------------------
// Quest to Move to the Passage of Hope.
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

[QuestScript(72261)]
public class Quest72261Script : QuestScript
{
	protected override void Load()
	{
		SetId(72261);
		SetName("Dusk and Dawn (2)");
		SetDescription("Move to the Passage of Hope");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_FINALE_02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(446));
		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_FINALE_DIRECTION_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_FINALE_RAIMA01", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("EP12_FINALE_02_DLG05");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

