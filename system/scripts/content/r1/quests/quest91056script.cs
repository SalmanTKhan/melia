//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (1)
//--- Description -----------------------------------------------------------
// Quest to Meet the lord of Orsha.
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

[QuestScript(91056)]
public class Quest91056Script : QuestScript
{
	protected override void Load()
	{
		SetId(91056);
		SetName("Secrets Hidden Underground (1)");
		SetDescription("Meet the lord of Orsha");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP13_2_DPRISON2_MQ_1_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_1_DLG1", "EP13_2_DPRISON2_MQ_1", "Leave it to me", "That's too difficult to do now"))
		{
			case 1:
				await dialog.Msg("EP13_2_DPRISON2_MQ_1_DLG2");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_1");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("EP13_2_DPRISON2_MQ_1_DLG5");
		dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_1");
		dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

