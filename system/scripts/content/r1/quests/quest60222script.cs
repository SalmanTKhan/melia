//--- Melia Script -----------------------------------------------------------
// Collect the Magic in Salvia Forest
//--- Description -----------------------------------------------------------
// Quest to Collect the Magic in Salvia Forest.
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

[QuestScript(60222)]
public class Quest60222Script : QuestScript
{
	protected override void Load()
	{
		SetId(60222);
		SetName("Collect the Magic in Salvia Forest");
		SetDescription("Collect the Magic in Salvia Forest");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 6));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 3));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 1));
	}
}

