//--- Melia Script -----------------------------------------------------------
// Eatables
//--- Description -----------------------------------------------------------
// Quest to Talk to Horace.
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

[QuestScript(70225)]
public class Quest70225Script : QuestScript
{
	protected override void Load()
	{
		SetId(70225);
		SetName("Eatables");
		SetDescription("Talk to Horace");

		AddPrerequisite(new LevelPrerequisite(215));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_2_SQ05"));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_06_1", "TABLELAND28_2_SQ06", "How can I help you?", "You better take some rest first"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_06_2");
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

		if (character.Inventory.HasItem("TABLELAND28_2_SQ06_ITEM2", 10))
		{
			character.Inventory.RemoveItem("TABLELAND28_2_SQ06_ITEM2", 10);
			await dialog.Msg("TABLELAND28_2_SQ_06_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

