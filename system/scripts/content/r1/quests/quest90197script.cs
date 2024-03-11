//--- Melia Script -----------------------------------------------------------
// Ritual for the Sea(3)
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

[QuestScript(90197)]
public class Quest90197Script : QuestScript
{
	protected override void Load()
	{
		SetId(90197);
		SetName("Ritual for the Sea(3)");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_90"));

		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_MAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_100_ST", "CORAL_44_1_SQ_100", "I'll go first.", "I'll wait."))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_100_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CORAL_44_1_SQ_100_SU");
		dialog.HideNPC("CORAL_44_1_OLDMAN2");
		dialog.HideNPC("CORAL_44_1_MAN1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

