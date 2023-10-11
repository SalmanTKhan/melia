//--- Melia Script -----------------------------------------------------------
// Destroy the last Black Crystal
//--- Description -----------------------------------------------------------
// Quest to Destroy Black Crystal.
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

[QuestScript(91045)]
public class Quest91045Script : QuestScript
{
	protected override void Load()
	{
		SetId(91045);
		SetName("Destroy the last Black Crystal");
		SetDescription("Destroy Black Crystal");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_F_SIAULIAI_2_MQ_07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_06"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_07_DLG1", "EP13_F_SIAULIAI_2_MQ_07", "Attack the Black Crystal", "Stop since it's dangerous"))
		{
			case 1:
				dialog.HideNPC("EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL");
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_07_AFTER");
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_LADA_3");
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

		await dialog.Msg("EP13_F_SIAULIAI_2_MQ_07_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

