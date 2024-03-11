//--- Melia Script -----------------------------------------------------------
// A Historical Theft
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(72152)]
public class Quest72152Script : QuestScript
{
	protected override void Load()
	{
		SetId(72152);
		SetName("A Historical Theft");
		SetDescription("Talk to the Cryomancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MASTER_ICEMAGE1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(15));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_ICEMAGE1_DLG1", "MASTER_ICEMAGE1", "I will try", "It looks dangerous"))
		{
			case 1:
				await dialog.Msg("JOB_ICEMAGE1_AG");
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

		await dialog.Msg("MASTER_ICEMAGE1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

