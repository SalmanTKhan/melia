//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (2)
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

[QuestScript(90011)]
public class Quest90011Script : QuestScript
{
	protected override void Load()
	{
		SetId(90011);
		SetName("Clear the Corruption (2)");
		SetDescription("Talk to Elder Aloizard");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_84_MQ_02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_01"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_MQ_02_DLG_01", "F_3CMLAKE_84_MQ_02", "Joining Forces", "Let me know if you find a way"))
		{
			case 1:
				// Func/SCR_F_3CMLAKE_84_MQ_02_PEOPLE;
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

