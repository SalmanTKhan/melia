//--- Melia Script -----------------------------------------------------------
// It's Only a Stone
//--- Description -----------------------------------------------------------
// Quest to Talk with Grave Robber Rudolfas.
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

[QuestScript(80222)]
public class Quest80222Script : QuestScript
{
	protected override void Load()
	{
		SetId(80222);
		SetName("It's Only a Stone");
		SetDescription("Talk with Grave Robber Rudolfas");

		AddPrerequisite(new LevelPrerequisite(187));
		AddPrerequisite(new CompletedPrerequisite("FLASH60_SQ_09"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_RUDOLFAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_RUDOLFAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ10_select01", "FLASH60_SQ10", "I'll try to find them", "I'll think about it."))
		{
			case 1:
				await dialog.Msg("FLASH60_SQ10_agree01");
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

		if (character.Inventory.HasItem("FLASH60_SQ10_ITEM", 5))
		{
			character.Inventory.RemoveItem("FLASH60_SQ10_ITEM", 5);
			await dialog.Msg("FLASH60_SQ10_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

