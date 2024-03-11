//--- Melia Script -----------------------------------------------------------
// Complicated Preparations(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70805)]
public class Quest70805Script : QuestScript
{
	protected override void Load()
	{
		SetId(70805);
		SetName("Complicated Preparations(1)");
		SetDescription("Talk to Vilhelmas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ05"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES231_SQ_06_start", "WHITETREES23_1_SQ06", "Ask what ingredients are needed", "Decline the small tasks"))
		{
			case 1:
				await dialog.Msg("WHITETREES231_SQ_06_agree");
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

		if (character.Inventory.HasItem("WHITETREES23_1_SQ06_ITEM2", 8))
		{
			character.Inventory.RemoveItem("WHITETREES23_1_SQ06_ITEM2", 8);
			await dialog.Msg("WHITETREES231_SQ_06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

