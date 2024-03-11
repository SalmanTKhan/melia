//--- Melia Script -----------------------------------------------------------
// Death as a Human (2)
//--- Description -----------------------------------------------------------
// Quest to Check Pajauta's Status.
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

[QuestScript(91071)]
public class Quest91071Script : QuestScript
{
	protected override void Load()
	{
		SetId(91071);
		SetName("Death as a Human (2)");
		SetDescription("Check Pajauta's Status");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON3_MQ_8_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_7"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_6", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON3_MQ_8_DLG1", "EP13_2_DPRISON3_MQ_8", "Passed out", "I'll check again"))
		{
			case 1:
				dialog.HideNPC("EP13_2_DPRISON3_MQ_NPC_5");
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

		await dialog.Msg("EP13_2_DPRISON3_MQ_8_DLG2");
		dialog.HideNPC("EP13_2_DPRISON3_MQ_DUMMY");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

