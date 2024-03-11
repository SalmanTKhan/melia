//--- Melia Script -----------------------------------------------------------
// Destroy the Massive Kruvina(1) 
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90215)]
public class Quest90215Script : QuestScript
{
	protected override void Load()
	{
		SetId(90215);
		SetName("Destroy the Massive Kruvina(1) ");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CORAL_44_3_SQ_50_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_40"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_3_OLDMAN3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_50_ST", "CORAL_44_3_SQ_50", "I'll stop the device", "That's a bit more than what I can do."))
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

		await dialog.Msg("CORAL_44_3_SQ_50_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

