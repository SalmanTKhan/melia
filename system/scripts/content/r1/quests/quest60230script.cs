//--- Melia Script -----------------------------------------------------------
// This Time For Sure
//--- Description -----------------------------------------------------------
// Quest to Open the Phamer Forest Treasure Chest.
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

[QuestScript(60230)]
public class Quest60230Script : QuestScript
{
	protected override void Load()
	{
		SetId(60230);
		SetName("This Time For Sure");
		SetDescription("Open the Phamer Forest Treasure Chest");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_2_1", 5));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_2", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_3", 1));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_5", 1));
	}
}

