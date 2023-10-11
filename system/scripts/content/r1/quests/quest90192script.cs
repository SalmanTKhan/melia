//--- Melia Script -----------------------------------------------------------
// The Missing Loremaster
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90192)]
public class Quest90192Script : QuestScript
{
	protected override void Load()
	{
		SetId(90192);
		SetName("The Missing Loremaster");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_44_1_SQ_50_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_40"));

		AddObjective("kill0", "Kill 5 Aphisher(s) or Gob(s)", new KillObjective(5, 58820, 58821));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_1_OLDMAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_MAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_50_ST", "CORAL_44_1_SQ_50", "I'll go there", "That sounds difficult."))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_50_AG");
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

		await dialog.Msg("CORAL_44_1_SQ_50_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

