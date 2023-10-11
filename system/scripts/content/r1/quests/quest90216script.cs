//--- Melia Script -----------------------------------------------------------
// Destroy the Massive Kruvina(2) 
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

[QuestScript(90216)]
public class Quest90216Script : QuestScript
{
	protected override void Load()
	{
		SetId(90216);
		SetName("Destroy the Massive Kruvina(2) ");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_44_3_SQ_60_TRACK", "m_boss_scenario3");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_50"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_3_OLDMAN3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_60_ST", "CORAL_44_3_SQ_60", "All prepared", "Please wait a little."))
		{
			case 1:
				await dialog.Msg("CORAL_44_3_SQ_60_AG");
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

		await dialog.Msg("CORAL_44_3_SQ_60_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

