//--- Melia Script -----------------------------------------------------------
// Preparing for the Future (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Verta.
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

[QuestScript(90081)]
public class Quest90081Script : QuestScript
{
	protected override void Load()
	{
		SetId(90081);
		SetName("Preparing for the Future (2)");
		SetDescription("Talk to Loremaster Verta");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_12"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 4));

		AddDialogHook("CORAL_32_2_BERTA2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_13_ST", "CORAL_32_2_SQ_13", "I'll do it; I'll place the stones.", "Sorry, I need to get going now."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_13_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_13_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

