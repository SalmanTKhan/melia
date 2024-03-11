//--- Melia Script -----------------------------------------------------------
// Demon Search (2)
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

[QuestScript(90130)]
public class Quest90130Script : QuestScript
{
	protected override void Load()
	{
		SetId(90130);
		SetName("Demon Search (2)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_10"));

		AddObjective("collect0", "Collect 8 Demon Orders(s)", new CollectItemObjective("F_DCAPITAL_20_5_SQ_10_ITEM", 8));
		AddDrop("F_DCAPITAL_20_5_SQ_10_ITEM", 10f, 57674, 58561, 58560);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_5_SQ_20_ST", "F_DCAPITAL_20_5_SQ_20", "I wll find the written orders.", "There is no way something like that would be."))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_5_SQ_20_AG");
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

		if (character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_10_ITEM", 8))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_10_ITEM", 8);
			await dialog.Msg("F_DCAPITAL_20_5_SQ_20_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

