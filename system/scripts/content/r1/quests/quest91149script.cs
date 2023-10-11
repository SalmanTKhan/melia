//--- Melia Script -----------------------------------------------------------
// Demon Army Blocking the Way
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91149)]
public class Quest91149Script : QuestScript
{
	protected override void Load()
	{
		SetId(91149);
		SetName("Demon Army Blocking the Way");
		SetDescription("Talk to General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE2_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(475));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_5"));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_2_LAMIN1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_2_LAMIN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE2_MQ_6_DLG1", "EP14_2_DCASTLE2_MQ_6", "Alright", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("EP14_2_2_LAMIN1");
				dialog.HideNPC("EP14_2_2_PAJAUTA1");
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

		await dialog.Msg("EP14_2_DCASTLE2_MQ_6_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

