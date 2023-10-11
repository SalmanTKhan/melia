//--- Melia Script -----------------------------------------------------------
// Baiga's Suggestion
//--- Description -----------------------------------------------------------
// Quest to Talk to Baiga.
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

[QuestScript(91051)]
public class Quest91051Script : QuestScript
{
	protected override void Load()
	{
		SetId(91051);
		SetName("Baiga's Suggestion");
		SetDescription("Talk to Baiga");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_F_SIAULIAI_3_MQ_05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_04"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_BAIGA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_05_DLG1", "EP13_F_SIAULIAI_3_MQ_05", "Ask the purpose", "Ask about the Root of the Divine Tree", "Leave the place."))
		{
			case 1:
				dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_BAIGA_1");
				dialog.UnHideNPC("EP13_F_SIAULIAI_3_MQ_LADA_3");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("EP13_F_SIAULIAI_3_MQ_05_DLG2");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP13_F_SIAULIAI_3_MQ_05_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

