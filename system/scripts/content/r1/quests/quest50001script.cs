//--- Melia Script -----------------------------------------------------------
// Disintegration (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Benedict.
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

[QuestScript(50001)]
public class Quest50001Script : QuestScript
{
	protected override void Load()
	{
		SetId(50001);
		SetName("Disintegration (2)");
		SetDescription("Talk to Priest Benedict");

		AddPrerequisite(new LevelPrerequisite(138));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_SQ05"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3450));

		AddDialogHook("CHATHEDRAL53_SQ02", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_SQ06_select01", "CHATHEDRAL53_SQ06", "I can get them for sure", "I should go back"))
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

		if (character.Inventory.HasItem("CATHEDRAL53_SQ_SAMPLE02", 6))
		{
			character.Inventory.RemoveItem("CATHEDRAL53_SQ_SAMPLE02", 6);
			await dialog.Msg("CHATHEDRAL53_SQ06_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

