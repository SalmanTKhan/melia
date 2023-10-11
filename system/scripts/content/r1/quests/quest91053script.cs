//--- Melia Script -----------------------------------------------------------
// Mirtinas' Whereabouts (2)
//--- Description -----------------------------------------------------------
// Quest to Ask Goddess Lada about her condition.
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

[QuestScript(91053)]
public class Quest91053Script : QuestScript
{
	protected override void Load()
	{
		SetId(91053);
		SetName("Mirtinas' Whereabouts (2)");
		SetDescription("Ask Goddess Lada about her condition");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_3_MQ_07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_06"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28148));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_3", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_3_MQ_07_CRACK_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_07_DLG1", "EP13_F_SIAULIAI_3_MQ_07", "I'll go to the Gatves Highway first", "There's no need to rush"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_3_MQ_07_DLG2");
				dialog.UnHideNPC("EP13_F_SIAULIAI_3_MQ_07_TRACK_1");
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

		await dialog.Msg("BalloonText/EP13_F_SIAULIAI_3_MQ_07_DLG4/5");
		dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_LADA_3");
		dialog.UnHideNPC("EP13_F_SIAULIAI_3_MQ_LADA_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

