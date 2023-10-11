//--- Melia Script -----------------------------------------------------------
// Find the Metal Plate
//--- Description -----------------------------------------------------------
// Quest to Use the detection stick to find Metal Plates at Folsas Highway.
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

[QuestScript(40751)]
public class Quest40751Script : QuestScript
{
	protected override void Load()
	{
		SetId(40751);
		SetName("Find the Metal Plate");
		SetDescription("Use the detection stick to find Metal Plates at Folsas Highway");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_080"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_090_AC", "REMAINS37_3_SQ_091", "I will go", "Tell him there will be no more"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_090_AG");
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

		await dialog.Msg("REMAINS37_3_SQ_091_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

