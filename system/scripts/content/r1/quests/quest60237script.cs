//--- Melia Script -----------------------------------------------------------
// The Lake Rafene
//--- Description -----------------------------------------------------------
// Quest to Obtain the Lake Rafene's Claws.
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

[QuestScript(60237)]
public class Quest60237Script : QuestScript
{
	protected override void Load()
	{
		SetId(60237);
		SetName("The Lake Rafene");
		SetDescription("Obtain the Lake Rafene's Claws");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Lake Rafene Claw", new CollectItemObjective("NUNNERY_KQ_2_ITEM", 1));
		AddDrop("NUNNERY_KQ_2_ITEM", 10f, "boss_Lapene");

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

		if (character.Inventory.HasItem("NUNNERY_KQ_2_ITEM", 1))
		{
			character.Inventory.RemoveItem("NUNNERY_KQ_2_ITEM", 1);
			await dialog.Msg("NUNNERY_KQ_2_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

