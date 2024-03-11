//--- Melia Script -----------------------------------------------------------
// Talk to Knight Titas (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sentinel.
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

[QuestScript(1001)]
public class Quest1001Script : QuestScript
{
	protected override void Load()
	{
		SetId(1001);
		SetName("Talk to Knight Titas (1)");
		SetDescription("Talk to the Sentinel");

		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU_WEST_START_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("SIAUL_WEST_MEET_TITAS_AUTO", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_CAMP_MANAGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Quests.Start(this.QuestId);
		await character.Tracks.Start(this.TrackData, "SIAUL_WEST_MEET_TITAS_TRACK");

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

