//--- Melia Script -----------------------------------------------------------
// Raising an Altar(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90071)]
public class Quest90071Script : QuestScript
{
	protected override void Load()
	{
		SetId(90071);
		SetName("Raising an Altar(1)");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_2"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 1));

		AddDialogHook("CORAL_32_2_DARUL1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_DARUL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_3_ST", "CORAL_32_2_SQ_3", "What can I help you with?", "I don't think I can help you, sorry."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_3_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_3_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

