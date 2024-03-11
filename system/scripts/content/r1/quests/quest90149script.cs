//--- Melia Script -----------------------------------------------------------
// Alarm Installation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90149)]
public class Quest90149Script : QuestScript
{
	protected override void Load()
	{
		SetId(90149);
		SetName("Alarm Installation (1)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(295));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_90"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_6_SQ_100_ST", "F_DCAPITAL_20_6_SQ_100", "I will come back with gathered demon power.", "This is where we part our ways."))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_6_SQ_100_AG");
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

		if (character.Inventory.HasItem("F_DCAPITAL_20_6_SQ_100_ITEM", 8))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_6_SQ_100_ITEM", 8);
			await dialog.Msg("F_DCAPITAL_20_6_SQ_100_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

