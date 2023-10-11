//--- Melia Script -----------------------------------------------------------
// Eyes That See Far
//--- Description -----------------------------------------------------------
// Quest to Collect Power.
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

[QuestScript(60223)]
public class Quest60223Script : QuestScript
{
	protected override void Load()
	{
		SetId(60223);
		SetName("Eyes That See Far");
		SetDescription("Collect Power");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 5));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 2));
	}
}

