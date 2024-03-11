//--- Melia Script -----------------------------------------------------------
// Forces Who Occupied the Paupys Crossing (1)
//--- Description -----------------------------------------------------------
// Quest to Meet Goddess Lada in Paupys Crossing.
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

[QuestScript(91047)]
public class Quest91047Script : QuestScript
{
	protected override void Load()
	{
		SetId(91047);
		SetName("Forces Who Occupied the Paupys Crossing (1)");
		SetDescription("Meet Goddess Lada in Paupys Crossing");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_F_SIAULIAI_3_MQ_01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_08"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_01_DLG1", "EP13_F_SIAULIAI_3_MQ_01", "I wan to hear about the Paupys Crossing", "There is more emergent issue"))
		{
			case 1:
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

		await dialog.Msg("EP13_F_SIAULIAI_3_MQ_01_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

