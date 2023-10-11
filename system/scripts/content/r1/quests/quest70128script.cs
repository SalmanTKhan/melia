//--- Melia Script -----------------------------------------------------------
// A Worthy Opponent
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Bastille.
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

[QuestScript(70128)]
public class Quest70128Script : QuestScript
{
	protected override void Load()
	{
		SetId(70128);
		SetName("A Worthy Opponent");
		SetDescription("Talk to Hunter Bastille");

		AddPrerequisite(new LevelPrerequisite(176));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_SQ_01_1", "THORN39_1_SQ01", "I'll help", "I don't have time for that"))
		{
			case 1:
				// Func/SCR_THORN391_SQ_01_COMPANION_GET;
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

		if (character.Inventory.HasItem("THORN39_1_SQ01_ITEM", 8))
		{
			character.Inventory.RemoveItem("THORN39_1_SQ01_ITEM", 8);
			await dialog.Msg("THORN39_1_SQ_01_3");
			// Func/SCR_THORN391_COMPANION_RETURN;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

