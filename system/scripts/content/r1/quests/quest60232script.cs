//--- Melia Script -----------------------------------------------------------
// Seeing For The First Time
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

[QuestScript(60232)]
public class Quest60232Script : QuestScript
{
	protected override void Load()
	{
		SetId(60232);
		SetName("Seeing For The First Time");
		SetDescription("Collect Power");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_2_1", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_2", 1));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_3", 4));
	}
}

