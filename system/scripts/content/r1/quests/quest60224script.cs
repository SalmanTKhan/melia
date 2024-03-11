//--- Melia Script -----------------------------------------------------------
// Collect Cave Magic
//--- Description -----------------------------------------------------------
// Quest to Collect Magic at the Tevhrin Stalactite Cave Section 1.
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

[QuestScript(60224)]
public class Quest60224Script : QuestScript
{
	protected override void Load()
	{
		SetId(60224);
		SetName("Collect Cave Magic");
		SetDescription("Collect Magic at the Tevhrin Stalactite Cave Section 1");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 6));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 3));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 1));
	}
}

