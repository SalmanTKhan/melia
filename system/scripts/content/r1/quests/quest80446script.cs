//--- Melia Script -----------------------------------------------------------
// Goddess Austeja's Request (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80446)]
public class Quest80446Script : QuestScript
{
	protected override void Load()
	{
		SetId(80446);
		SetName("Goddess Austeja's Request (2)");
		SetDescription("Talk to Goddess Austeja");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "D_CASTLE_19_1_MQ_05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(421));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24418));

		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_05_ST", "D_CASTLE_19_1_MQ_05", "Leave it to me.", "Sounds like too much trouble."))
		{
			case 1:
				await dialog.Msg("D_CASTLE_19_1_MQ_05_AFST");
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

		await dialog.Msg("D_CASTLE_19_1_MQ_05_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

