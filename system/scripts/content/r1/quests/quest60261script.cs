//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Danute.
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

[QuestScript(60261)]
public class Quest60261Script : QuestScript
{
	protected override void Load()
	{
		SetId(60261);
		SetName("Necessary Mistake (7)");
		SetDescription("Talk to Kupole Danute");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB483_MQ_7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_6"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_DANUTE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_DANUTE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_7_1", "FANTASYLIB483_MQ_7", "I'll protect it with my life.", "I need to prepare"))
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

		await dialog.Msg("FANTASYLIB483_MQ_7_3");
		dialog.HideNPC("FLIBRARY483_DANUTE_NPC");
		dialog.UnHideNPC("FLIBRARY483_NERINGA_NPC_3");
		await dialog.Msg("FadeOutIN/3000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

