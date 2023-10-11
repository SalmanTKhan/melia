//--- Melia Script -----------------------------------------------------------
// Collecting Research
//--- Description -----------------------------------------------------------
// Quest to Talk to Alruida.
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

[QuestScript(40760)]
public class Quest40760Script : QuestScript
{
	protected override void Load()
	{
		SetId(40760);
		SetName("Collecting Research");
		SetDescription("Talk to Alruida");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_060"), new CompletedPrerequisite("REMAINS37_3_SQ_091"));

		AddReward(new ItemReward("REMAINS37_3_SQ_100_ITEM_1", 1));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_100_ST", "REMAINS37_3_SQ_100", "I will hand them over to Justas", "I will leave since there's nothing you could help anymore"))
		{
			case 1:
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

		await dialog.Msg("REMAINS37_3_SQ_100_COMP");
		await Task.Delay(2000);
		await dialog.Msg("REMAINS37_3_SQ_100_COMP_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

