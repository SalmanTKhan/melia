//--- Melia Script -----------------------------------------------------------
// Waiting for Daddy (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Little Willitte.
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

[QuestScript(90127)]
public class Quest90127Script : QuestScript
{
	protected override void Load()
	{
		SetId(90127);
		SetName("Waiting for Daddy (1)");
		SetDescription("Talk with Little Willitte");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "MAPLE_25_2_SQ_90_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 8 Rhodeliot(s)", new KillObjective(8, MonsterId.Roderiot));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("MAPLE_25_2_SQ_90", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_VILITA", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("MAPLE_25_2_SQ_90_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

