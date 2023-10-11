//--- Melia Script -----------------------------------------------------------
// Caltrop instead of a Caltrop
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

[QuestScript(70223)]
public class Quest70223Script : QuestScript
{
	protected override void Load()
	{
		SetId(70223);
		SetName("Caltrop instead of a Caltrop");
		SetDescription("Talk with Supply Officer Ronda");

		AddPrerequisite(new LevelPrerequisite(215));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_2_SQ02"), new CompletedPrerequisite("TABLELAND28_2_SQ03"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_04_1", "TABLELAND28_2_SQ04", "I will find adequate bars for you", "About the old bars", "I can't help you with that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("TABLELAND28_2_SQ_04_2");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("TABLELAND28_2_SQ04_ITEM", 10))
		{
			character.Inventory.RemoveItem("TABLELAND28_2_SQ04_ITEM", 10);
			await dialog.Msg("TABLELAND28_2_SQ_04_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

