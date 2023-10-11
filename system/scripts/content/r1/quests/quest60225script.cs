//--- Melia Script -----------------------------------------------------------
// Old Tool
//--- Description -----------------------------------------------------------
// Quest to Collect Old Tools.
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

[QuestScript(60225)]
public class Quest60225Script : QuestScript
{
	protected override void Load()
	{
		SetId(60225);
		SetName("Old Tool");
		SetDescription("Collect Old Tools");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 5));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 2));
	}
}

