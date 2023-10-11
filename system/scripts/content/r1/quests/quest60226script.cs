//--- Melia Script -----------------------------------------------------------
// Someone's Good Will
//--- Description -----------------------------------------------------------
// Quest to Open the Rasvoy Lake Treasure Chest.
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

[QuestScript(60226)]
public class Quest60226Script : QuestScript
{
	protected override void Load()
	{
		SetId(60226);
		SetName("Someone's Good Will");
		SetDescription("Open the Rasvoy Lake Treasure Chest");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 6));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 3));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 1));
	}
}

