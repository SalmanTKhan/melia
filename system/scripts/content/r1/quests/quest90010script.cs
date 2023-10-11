//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Aloizard.
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

[QuestScript(90010)]
public class Quest90010Script : QuestScript
{
	protected override void Load()
	{
		SetId(90010);
		SetName("Clear the Corruption (1)");
		SetDescription("Talk to Elder Aloizard");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_84_MQ_01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_05"));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_MQ_01_DLG_01", "F_3CMLAKE_84_MQ_01", "I will investigate it", "It's not time for that yet"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_84_MQ_01_DLG_02");
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


		return HookResult.Break;
	}
}

