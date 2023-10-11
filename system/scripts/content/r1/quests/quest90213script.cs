//--- Melia Script -----------------------------------------------------------
// Destroy the Demon Device(2)
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

[QuestScript(90213)]
public class Quest90213Script : QuestScript
{
	protected override void Load()
	{
		SetId(90213);
		SetName("Destroy the Demon Device(2)");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CORAL_44_3_SQ_30_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_20"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_3_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_30_ST", "CORAL_44_3_SQ_30"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CORAL_44_3_SQ_30_SU");
		dialog.HideNPC("CORAL_44_3_OLDMAN2");
		await dialog.Msg("FadeOutIN/3000");
		dialog.UnHideNPC("CORAL_44_3_OLDMAN3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

