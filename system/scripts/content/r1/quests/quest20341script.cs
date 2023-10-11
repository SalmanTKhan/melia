//--- Melia Script -----------------------------------------------------------
// The Bishop's Last Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Obtain the revelation of the Great Cathedral.
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

[QuestScript(20341)]
public class Quest20341Script : QuestScript
{
	protected override void Load()
	{
		SetId(20341);
		SetName("The Bishop's Last Mission (2)");
		SetDescription("Obtain the revelation of the Great Cathedral");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL54_MQ06_PART3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ05_PART3"));

		AddReward(new ExpReward(2351312, 2351312));
		AddReward(new ItemReward("stonetablet06", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 111));
		AddReward(new ItemReward("Vis", 49010));

		AddDialogHook("MQ05_PROOF_PRIST", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL_FINAL_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ06_PART3_select", "CHATHEDRAL54_MQ06_PART3", "Accept", "Reject"))
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


		return HookResult.Break;
	}
}

