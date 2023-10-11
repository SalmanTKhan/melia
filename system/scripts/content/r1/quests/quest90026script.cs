//--- Melia Script -----------------------------------------------------------
// Settlement
//--- Description -----------------------------------------------------------
// Quest to Talk to Mayor Frege.
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

[QuestScript(90026)]
public class Quest90026Script : QuestScript
{
	protected override void Load()
	{
		SetId(90026);
		SetName("Settlement");
		SetDescription("Talk to Mayor Frege");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_6"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_PEOPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_PEOPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_7_ST", "CORAL_32_1_SQ_7", "Tell him that you will get rid of the rest of the pockets", "That won't be a problem"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_7_AG");
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

		await dialog.Msg("CORAL_32_1_SQ_7_SU");
		dialog.HideNPC("CORAL_32_1_HIDDEN_TRAP2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

