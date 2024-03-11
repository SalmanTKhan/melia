//--- Melia Script -----------------------------------------------------------
// Recover the Convent Records
//--- Description -----------------------------------------------------------
// Quest to Recover the Convent Records.
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

[QuestScript(60236)]
public class Quest60236Script : QuestScript
{
	protected override void Load()
	{
		SetId(60236);
		SetName("Recover the Convent Records");
		SetDescription("Recover the Convent Records");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 20 Convent Records(s)", new CollectItemObjective("NUNNERY_KQ_1_ITEM", 20));
		AddDrop("NUNNERY_KQ_1_ITEM", 7f, "ALL");

		AddReward(new ItemReward("KQ_recipe_hethran_material_2_1", 5));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_2", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_3", 1));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_5", 1));

		AddDialogHook("ENCHANTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("NUNNERY_KQ_1_ITEM", 20))
		{
			character.Inventory.RemoveItem("NUNNERY_KQ_1_ITEM", 20);
			await dialog.Msg("NUNNERY_KQ_1_1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

