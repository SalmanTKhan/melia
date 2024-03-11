//--- Melia Script -----------------------------------------------------------
// New Product
//--- Description -----------------------------------------------------------
// Quest to Ask Merchant Felicia about the corals.
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

[QuestScript(90028)]
public class Quest90028Script : QuestScript
{
	protected override void Load()
	{
		SetId(90028);
		SetName("New Product");
		SetDescription("Ask Merchant Felicia about the corals");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_6"));
		AddPrerequisite(new ItemPrerequisite("CORAL_32_1_SQ_9_ITEM", -100));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_MERCHANT2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_9_ST", "CORAL_32_1_SQ_9", "I will definitely help for the villagers", "I'm busy"))
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

		await dialog.Msg("CORAL_32_1_SQ_9_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

