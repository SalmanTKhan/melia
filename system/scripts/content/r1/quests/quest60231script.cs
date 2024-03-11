//--- Melia Script -----------------------------------------------------------
// Underground Ecosystem
//--- Description -----------------------------------------------------------
// Quest to Collect Cave Sap.
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

[QuestScript(60231)]
public class Quest60231Script : QuestScript
{
	protected override void Load()
	{
		SetId(60231);
		SetName("Underground Ecosystem");
		SetDescription("Collect Cave Sap");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_2_1", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_2", 1));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_3", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_5", 1));
	}
}

