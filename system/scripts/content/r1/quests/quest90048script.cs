//--- Melia Script -----------------------------------------------------------
// Fainted or Asleep? (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sleeping Owl Sculpture.
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

[QuestScript(90048)]
public class Quest90048Script : QuestScript
{
	protected override void Load()
	{
		SetId(90048);
		SetName("Fainted or Asleep? (2)");
		SetDescription("Talk to the Sleeping Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_6"));

		AddDialogHook("KATYN_45_2_OWL4", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_7_ST", "KATYN_45_2_SQ_7", "Tell me about the girl and the man chasing her.", "Let's give it some time."))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_7_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_7_AU");
		dialog.HideNPC("KATYN_45_2_AJEL3");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("KATYN_45_3_AJEL1");
		await dialog.Msg("BalloonText/KATYN_45_2_SQ_7_SU/3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

