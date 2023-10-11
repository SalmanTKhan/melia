//--- Melia Script -----------------------------------------------------------
// Resolve the Tussle (3)
//--- Description -----------------------------------------------------------
// Quest to Help the soldiers in battle at the Ratas Crossroads and guide them to the base.
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

[QuestScript(91097)]
public class Quest91097Script : QuestScript
{
	protected override void Load()
	{
		SetId(91097);
		SetName("Resolve the Tussle (3)");
		SetDescription("Help the soldiers in battle at the Ratas Crossroads and guide them to the base");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_5"));

		AddObjective("kill0", "Kill 20 Blickferret Fighter(s) or Blickferret Swordsman(s) or Blickferret Shielder(s)", new KillObjective(20, 59695, 59696, 59697));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));
	}
}

