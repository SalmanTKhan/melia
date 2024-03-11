//--- Melia Script -----------------------------------------------------------
// Merchant's Lost Wares
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Dulke.
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

[QuestScript(16720)]
public class Quest16720Script : QuestScript
{
	protected override void Load()
	{
		SetId(16720);
		SetName("Merchant's Lost Wares");
		SetDescription("Talk to Merchant Dulke");

		AddPrerequisite(new LevelPrerequisite(169));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_SQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_1_SQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_1_SQ_03_select", "SIAULIAI_46_1_SQ_03", "I will find it back so don't worry", "About the addled Revelators", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_1_SQ_03_start_prog");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_46_1_SQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("SIAULIAI_46_1_SQ_03_ITEM", 3))
		{
			character.Inventory.RemoveItem("SIAULIAI_46_1_SQ_03_ITEM", 3);
			await dialog.Msg("SIAULIAI_46_1_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

