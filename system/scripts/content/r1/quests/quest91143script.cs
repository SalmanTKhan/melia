//--- Melia Script -----------------------------------------------------------
// Where Ominous Energy Leaks From (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ramin.
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

[QuestScript(91143)]
public class Quest91143Script : QuestScript
{
	protected override void Load()
	{
		SetId(91143);
		SetName("Where Ominous Energy Leaks From (2)");
		SetDescription("Talk to Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE1_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_9"));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_Lamin2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_Lamin2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE1_MQ_10_DLG1", "EP14_2_DCASTLE1_MQ_10", "Alright", "It's dangerous to touch the barrier carelessly."))
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

		await dialog.Msg("EP14_2_DCASTLE1_MQ_10_DLG3");
		await dialog.Msg("FadeOutIN/3000");
		dialog.HideNPC("EP14_2_1_Lamin2");
		dialog.HideNPC("EP14_2_1_PAJAUTA2");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

