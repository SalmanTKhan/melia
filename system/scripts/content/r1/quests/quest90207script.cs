//--- Melia Script -----------------------------------------------------------
// Towards Epherotao Coast
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

[QuestScript(90207)]
public class Quest90207Script : QuestScript
{
	protected override void Load()
	{
		SetId(90207);
		SetName("Towards Epherotao Coast");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(331));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_70"));

		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_2_SQ_80_ST", "CORAL_44_2_SQ_80", "Alright", "Ignore"))
		{
			case 1:
				await dialog.Msg("CORAL_44_2_SQ_80_AG");
				dialog.HideNPC("CORAL_44_2_MAN2");
				dialog.HideNPC("CORAL_44_2_OLDMAN2");
				await dialog.Msg("FadeOutIN/2500");
				dialog.UnHideNPC("CORAL_44_3_OLDMAN1");
				dialog.UnHideNPC("CORAL_44_3_MAN1");
				dialog.UnHideNPC("CORAL_44_2_MAN3");
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

		await dialog.Msg("CORAL_44_2_SQ_80_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

