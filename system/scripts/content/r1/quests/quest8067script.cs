//--- Melia Script -----------------------------------------------------------
// Investigate the Miners' Village
//--- Description -----------------------------------------------------------
// Quest to Arrive at the Miners' Village.
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

[QuestScript(8067)]
public class Quest8067Script : QuestScript
{
	protected override void Load()
	{
		SetId(8067);
		SetName("Investigate the Miners' Village");
		SetDescription("Arrive at the Miners' Village");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU_OUT_Q1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(10));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST7"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));

		AddDialogHook("SIAULIAIOUT_Q01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("SOUT_Q_01_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

