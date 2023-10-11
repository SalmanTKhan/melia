//--- Melia Script -----------------------------------------------------------
// Another Black Crystal
//--- Description -----------------------------------------------------------
// Quest to Investigate the Mirtinas Crevice again.
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

[QuestScript(91044)]
public class Quest91044Script : QuestScript
{
	protected override void Load()
	{
		SetId(91044);
		SetName("Another Black Crystal");
		SetDescription("Investigate the Mirtinas Crevice again");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP13_F_SIAULIAI_2_MQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_05"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_03_CRACK", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_06_DLG1", "EP13_F_SIAULIAI_2_MQ_06", "Investigate the Crevice", "Do other work for now"))
		{
			case 1:
				await dialog.Msg("BalloonText/EP13_F_SIAULIAI_2_MQ_06_DLG2/5");
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_06_SMOKE");
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

