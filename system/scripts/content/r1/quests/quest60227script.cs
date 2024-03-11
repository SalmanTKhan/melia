//--- Melia Script -----------------------------------------------------------
// Svalphinghas Forest in Trouble
//--- Description -----------------------------------------------------------
// Quest to Destroy the Mutated Tree Root Crystals.
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

[QuestScript(60227)]
public class Quest60227Script : QuestScript
{
	protected override void Load()
	{
		SetId(60227);
		SetName("Svalphinghas Forest in Trouble");
		SetDescription("Destroy the Mutated Tree Root Crystals");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("KQ_recipe_hethran_material_1_1", 5));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_2", 4));
		AddReward(new ItemReward("KQ_recipe_hethran_material_1_3", 2));
	}
}

