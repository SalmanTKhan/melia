//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91061)]
public class Quest91061Script : QuestScript
{
	protected override void Load()
	{
		SetId(91061);
		SetName("Secrets Hidden Underground (6)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_2_DPRISON2_MQ_6_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_5"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_6_DLG1", "EP13_2_DPRISON2_MQ_6", "Let's hurry", "Please wait a while"))
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

		await dialog.Msg("EP13_2_DPRISON2_MQ_6_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

