//--- Melia Script -----------------------------------------------------------
// To Eat Something
//--- Description -----------------------------------------------------------
// Quest to Talk with Supply Officer Ronda.
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

[QuestScript(70221)]
public class Quest70221Script : QuestScript
{
	protected override void Load()
	{
		SetId(70221);
		SetName("To Eat Something");
		SetDescription("Talk with Supply Officer Ronda");

		AddPrerequisite(new LevelPrerequisite(215));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_02_1", "TABLELAND28_2_SQ02", "How can I help you?", "I can't help you"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_02_2");
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

		if (character.Inventory.HasItem("TABLELAND28_2_SQ02_ITEM", 12))
		{
			character.Inventory.RemoveItem("TABLELAND28_2_SQ02_ITEM", 12);
			await dialog.Msg("TABLELAND28_2_SQ_02_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

