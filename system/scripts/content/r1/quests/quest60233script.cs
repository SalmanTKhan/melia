//--- Melia Script -----------------------------------------------------------
// Surrogate Observer
//--- Description -----------------------------------------------------------
// Quest to Investigate the Martuis Storage Room.
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

[QuestScript(60233)]
public class Quest60233Script : QuestScript
{
	protected override void Load()
	{
		SetId(60233);
		SetName("Surrogate Observer");
		SetDescription("Investigate the Martuis Storage Room");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_2_1", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_2", 1));
		AddReward(new ItemReward("KQ_recipe_hethran_material_2_3", 4));
	}
}

