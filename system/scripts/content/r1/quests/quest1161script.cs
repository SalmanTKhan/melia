//--- Melia Script -----------------------------------------------------------
// How to Use the TP Shop
//--- Description -----------------------------------------------------------
// Quest to Talk to TP Merchant Leticia in town..
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

[QuestScript(1161)]
public class Quest1161Script : QuestScript
{
	protected override void Load()
	{
		SetId(1161);
		SetName("How to Use the TP Shop");
		SetDescription("Talk to TP Merchant Leticia in town.");

		AddPrerequisite(new LevelPrerequisite(1));

		AddReward(new ItemReward("PremiumToken_1d", 1));

		AddDialogHook("TP_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("TP_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		//SCR_TUTO_TP_SHOP_SUCCESS_TX_FUNC
		await dialog.Msg("TUTO_TP_SHOP_SUCCESS_DLG1");
		// Func/SCR_TUTO_TP_SHOP_SUCCESS_FUNC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

