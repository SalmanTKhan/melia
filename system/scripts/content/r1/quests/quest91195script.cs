//--- Melia Script -----------------------------------------------------------
// Secret of the Oratory (1)
//--- Description -----------------------------------------------------------
// Quest to Read the dropped book.
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

[QuestScript(91195)]
public class Quest91195Script : QuestScript
{
	protected override void Load()
	{
		SetId(91195);
		SetName("Secret of the Oratory (1)");
		SetDescription("Read the dropped book");

		AddPrerequisite(new LevelPrerequisite(489));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_6"));

		AddReward(new ExpReward(4200000000, 4200000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_F_ABBEY_3_SQ1_BOOK1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_F_ABBEY_3_SQ1_BOOK2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY3_SQ1_DLG1", "EP15_1_F_ABBEY_3_SQ1", "Check it out.", "Turn back."))
		{
			case 1:
				// Func/SCR_EP15_1_FABBEY_3_SQ1_scroll_1_RUN;
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

		// Func/SCR_EP15_1_FABBEY_3_SQ1_scroll_2_RUN;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

