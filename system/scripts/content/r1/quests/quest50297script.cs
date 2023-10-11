//--- Melia Script -----------------------------------------------------------
// Just What I Was Craving
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Heulen.
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

[QuestScript(50297)]
public class Quest50297Script : QuestScript
{
	protected override void Load()
	{
		SetId(50297);
		SetName("Just What I Was Craving");
		SetDescription("Talk to Soldier Heulen");

		AddPrerequisite(new LevelPrerequisite(238));

		AddReward(new ItemReward("Gacha_H_009", 1));

		AddDialogHook("TABLE70_SOLDIER6_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_SOLDIER6_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND70_HQ1_start1", "TABLELAND70_HQ1", "I can get you some strawberries.", "You should get some from the supplies."))
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

		if (character.Inventory.HasItem("food_029", 30))
		{
			character.Inventory.RemoveItem("food_029", 30);
			await dialog.Msg("TABLELAND70_HQ1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

