//--- Melia Script -----------------------------------------------------------
// Gravegolem Core
//--- Description -----------------------------------------------------------
// Quest to Obtain 50 Gravegolem Cores on the Fasika Plateau.
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

[QuestScript(91222)]
public class Quest91222Script : QuestScript
{
	protected override void Load()
	{
		SetId(91222);
		SetName("Gravegolem Core");
		SetDescription("Obtain 50 Gravegolem Cores on the Fasika Plateau");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_PILGRIM_36_2_MQ11"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("EP16_1_PILGRIM_36_2_MQ12_ITEM", 50))
		{
			character.Inventory.RemoveItem("EP16_1_PILGRIM_36_2_MQ12_ITEM", 50);
			await dialog.Msg("EP16_1_PILGRIM_36_2_MQ12_NPC_DLG_2");
			// Func/SCR_EP16_1_PILGRIM_36_2_MQ12_TAKE_ITEM;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

